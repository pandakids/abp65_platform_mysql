using Abp.AspNetZeroCore.Web.Authentication.External;
using Abp.Domain.Repositories;
using Abp.Runtime.Caching;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Senparc.Weixin;
using Senparc.CO2NET.HttpUtility;
using Senparc.Weixin.Work.AdvancedAPIs.OAuth2;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hoooten.PlatformMysql.Web.Authentication.External
{
    public class WechatAuthProviderApi : ExternalAuthProviderApiBase
    {
        public const string Name = "Wechat";
        private readonly ICacheManager _cacheManager;
        private readonly IExternalAuthConfiguration _externalAuthConfiguration;
        WeChatMiniProgramOptions _options;
        JsonSchema schema = JsonSchema.Parse(JsonConvert.SerializeObject(new UsersWechat()));
        public WechatAuthProviderApi(ICacheManager cacheManager, IExternalAuthConfiguration externalAuthConfiguration)
        {
            _cacheManager = cacheManager;
            _externalAuthConfiguration = externalAuthConfiguration;
            var r = externalAuthConfiguration.Providers.First(p => p.Name == Name);
            _options = new WeChatMiniProgramOptions
            {
                AppId = r.ClientId,
                Secret = r.ClientSecret
            };

        }
        public override async Task<ExternalAuthUserInfo> GetUserInfo(string accessCode)
        {
            UsersWechat wechat = new UsersWechat();


            string accessToken = _cacheManager.GetCache("CacheName").Get("Login", () => GetToken(_options.AppId, _options.Secret));
            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                var url = string.Format(Config.ApiWorkHost + "/cgi-bin/user/getuserinfo?access_token={0}&code={1}", accessToken, accessCode);

                var redata = Get.GetJson<GetUserResult>(url);
                if (!string.IsNullOrWhiteSpace(redata.user_ticket))
                {
                    UserTicket tiket = new UserTicket
                    {
                        user_ticket = redata.user_ticket
                    };
                    url = string.Format(Config.ApiWorkHost + "/cgi-bin/user/getuserdetail?access_token={0}", accessToken);
                    //   wechat = Post.GetResult<UsersWechat>(JsonConvert.SerializeObject(tiket));
                    wechat = await GetUserMsg(url, tiket);
                }
            }

            var t = wechat == null ? new ExternalAuthUserInfo() : new ExternalAuthUserInfo
            {
                EmailAddress = wechat.email,
                Surname = wechat.name,
                ProviderKey = wechat.userid,
                Provider = Name,
                Name = wechat.userid
            };
            return t;

        }



        private async Task<UsersWechat> GetUserMsg(string url, UserTicket tiket)
        {
            //序列化将要传输的对象
            string obj = JsonConvert.SerializeObject(tiket);
            HttpContent content = new StringContent(obj);

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var result = await client.PostAsync(url, content);
            if (result.IsSuccessStatusCode)
            {
                string re = await result.Content.ReadAsStringAsync();
                var jo = JObject.Parse(re);
                if (jo.IsValid(schema))
                {
                    var m = JsonConvert.DeserializeObject<UsersWechat>(re);
                    return m;
                }
            }
            return null;
        }


        private string GetToken(string AppId, string Secret)
        {
            if (string.IsNullOrWhiteSpace(AppId) || string.IsNullOrWhiteSpace(Secret))
            {
                return "";
            }
            return Senparc.Weixin.Work.Containers.AccessTokenContainer.TryGetTokenAsync(AppId, Secret).Result;
        }

        public class UsersWechat
        {
            public string userid { get; set; }
            public string name { get; set; }

            public string mobile { get; set; }

            public string gender { get; set; }

            public string email { get; set; }

            public string avatar { get; set; }

            public string qr_code { get; set; }

        }

        public class GetUserResult
        {
            public string errcode { get; set; }
            public string errmsg { get; set; }
            public string CorpId { get; set; }
            public string UserId { get; set; }
            public string DeviceId { get; set; }

            public string user_ticket { get; set; }

            public string expires_in { get; set; }

        }

        public class UserTicket
        {
            public string user_ticket { get; set; }
        }

    }

    internal class WeChatMiniProgramOptions
    {
        public string AppId { get; internal set; }
        public string Secret { get; internal set; }
    }
}