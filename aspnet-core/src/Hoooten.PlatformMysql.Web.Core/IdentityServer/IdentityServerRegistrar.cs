﻿using Abp.IdentityServer4;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Hoooten.PlatformMysql.Authorization.Users;
using Hoooten.PlatformMysql.EntityFrameworkCore;

namespace Hoooten.PlatformMysql.Web.IdentityServer
{
    public static class IdentityServerRegistrar
    {
        public static void Register(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(IdentityServerConfig.GetIdentityResources())
                .AddInMemoryApiResources(IdentityServerConfig.GetApiResources())
                .AddInMemoryClients(IdentityServerConfig.GetClients(configuration))
                .AddAbpPersistedGrants<PlatformMysqlDbContext>()
                .AddAbpIdentityServer<User>();
        }
    }
}
