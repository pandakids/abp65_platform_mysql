using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Hoooten.PlatformMysql.Authentication.TwoFactor.Google;
using Hoooten.PlatformMysql.Authorization;
using Hoooten.PlatformMysql.Authorization.Roles;
using Hoooten.PlatformMysql.Authorization.Users;
using Hoooten.PlatformMysql.Editions;
using Hoooten.PlatformMysql.MultiTenancy;

namespace Hoooten.PlatformMysql.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>(options =>
                {
                    options.Tokens.ProviderMap[GoogleAuthenticatorProvider.Name] = new TokenProviderDescriptor(typeof(GoogleAuthenticatorProvider));
                })
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddPermissionChecker<PermissionChecker>()
                .AddDefaultTokenProviders();
        }
    }
}
