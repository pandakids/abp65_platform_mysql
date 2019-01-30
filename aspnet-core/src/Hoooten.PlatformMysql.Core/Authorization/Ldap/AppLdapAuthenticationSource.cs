using Abp.Zero.Ldap.Authentication;
using Abp.Zero.Ldap.Configuration;
using Hoooten.PlatformMysql.Authorization.Users;
using Hoooten.PlatformMysql.MultiTenancy;

namespace Hoooten.PlatformMysql.Authorization.Ldap
{
    public class AppLdapAuthenticationSource : LdapAuthenticationSource<Tenant, User>
    {
        public AppLdapAuthenticationSource(ILdapSettings settings, IAbpZeroLdapModuleConfig ldapModuleConfig)
            : base(settings, ldapModuleConfig)
        {
        }
    }
}