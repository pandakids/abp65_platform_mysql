﻿using Abp.Dependency;

namespace Hoooten.PlatformMysql.ApiClient.Models
{
    public class AbpAuthenticateModel : ISingletonDependency
    {
        public string UserNameOrEmailAddress { get; set; }

        public string Password { get; set; }

        public string TwoFactorVerificationCode { get; set; }

        public bool RememberClient { get; set; }

        public string TwoFactorRememberClientToken { get; set; }

        public bool? SingleSignIn { get; set; }

        public string ReturnUrl { get; set; }
    }
}