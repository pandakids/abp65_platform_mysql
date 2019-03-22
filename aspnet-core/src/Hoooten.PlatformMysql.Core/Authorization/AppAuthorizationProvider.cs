using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Hoooten.PlatformMysql.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class AppAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public AppAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public AppAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            var foreActivities = pages.CreateChildPermission(AppPermissions.Pages_ForeActivities, L("ForeActivities"), multiTenancySides: MultiTenancySides.Tenant);
            foreActivities.CreateChildPermission(AppPermissions.Pages_ForeActivities_Create, L("CreateNewForeActivity"), multiTenancySides: MultiTenancySides.Tenant);
            foreActivities.CreateChildPermission(AppPermissions.Pages_ForeActivities_Edit, L("EditForeActivity"), multiTenancySides: MultiTenancySides.Tenant);
            foreActivities.CreateChildPermission(AppPermissions.Pages_ForeActivities_Delete, L("DeleteForeActivity"), multiTenancySides: MultiTenancySides.Tenant);



            var userGifts = pages.CreateChildPermission(AppPermissions.Pages_UserGifts, L("UserGifts"), multiTenancySides: MultiTenancySides.Tenant);
            userGifts.CreateChildPermission(AppPermissions.Pages_UserGifts_Create, L("CreateNewUserGift"), multiTenancySides: MultiTenancySides.Tenant);
            userGifts.CreateChildPermission(AppPermissions.Pages_UserGifts_Edit, L("EditUserGift"), multiTenancySides: MultiTenancySides.Tenant);
            userGifts.CreateChildPermission(AppPermissions.Pages_UserGifts_Delete, L("DeleteUserGift"), multiTenancySides: MultiTenancySides.Tenant);



            var foreFatherGifts = pages.CreateChildPermission(AppPermissions.Pages_ForeFatherGifts, L("ForeFatherGifts"), multiTenancySides: MultiTenancySides.Tenant);
            foreFatherGifts.CreateChildPermission(AppPermissions.Pages_ForeFatherGifts_Create, L("CreateNewForeFatherGift"), multiTenancySides: MultiTenancySides.Tenant);
            foreFatherGifts.CreateChildPermission(AppPermissions.Pages_ForeFatherGifts_Edit, L("EditForeFatherGift"), multiTenancySides: MultiTenancySides.Tenant);
            foreFatherGifts.CreateChildPermission(AppPermissions.Pages_ForeFatherGifts_Delete, L("DeleteForeFatherGift"), multiTenancySides: MultiTenancySides.Tenant);



            var foreFathers = pages.CreateChildPermission(AppPermissions.Pages_ForeFathers, L("ForeFathers"), multiTenancySides: MultiTenancySides.Tenant);
            foreFathers.CreateChildPermission(AppPermissions.Pages_ForeFathers_Create, L("CreateNewForeFather"), multiTenancySides: MultiTenancySides.Tenant);
            foreFathers.CreateChildPermission(AppPermissions.Pages_ForeFathers_Edit, L("EditForeFather"), multiTenancySides: MultiTenancySides.Tenant);
            foreFathers.CreateChildPermission(AppPermissions.Pages_ForeFathers_Delete, L("DeleteForeFather"), multiTenancySides: MultiTenancySides.Tenant);



            var templeMembers = pages.CreateChildPermission(AppPermissions.Pages_TempleMembers, L("TempleMembers"), multiTenancySides: MultiTenancySides.Tenant);
            templeMembers.CreateChildPermission(AppPermissions.Pages_TempleMembers_Create, L("CreateNewTempleMember"), multiTenancySides: MultiTenancySides.Tenant);
            templeMembers.CreateChildPermission(AppPermissions.Pages_TempleMembers_Edit, L("EditTempleMember"), multiTenancySides: MultiTenancySides.Tenant);
            templeMembers.CreateChildPermission(AppPermissions.Pages_TempleMembers_Delete, L("DeleteTempleMember"), multiTenancySides: MultiTenancySides.Tenant);



            var temples = pages.CreateChildPermission(AppPermissions.Pages_Temples, L("Temples"), multiTenancySides: MultiTenancySides.Tenant);
            temples.CreateChildPermission(AppPermissions.Pages_Temples_Create, L("CreateNewTemple"), multiTenancySides: MultiTenancySides.Tenant);
            temples.CreateChildPermission(AppPermissions.Pages_Temples_Edit, L("EditTemple"), multiTenancySides: MultiTenancySides.Tenant);
            temples.CreateChildPermission(AppPermissions.Pages_Temples_Delete, L("DeleteTemple"), multiTenancySides: MultiTenancySides.Tenant);



            var cities = pages.CreateChildPermission(AppPermissions.Pages_Cities, L("Cities"), multiTenancySides: MultiTenancySides.Tenant);
            cities.CreateChildPermission(AppPermissions.Pages_Cities_Create, L("CreateNewCity"), multiTenancySides: MultiTenancySides.Tenant);
            cities.CreateChildPermission(AppPermissions.Pages_Cities_Edit, L("EditCity"), multiTenancySides: MultiTenancySides.Tenant);
            cities.CreateChildPermission(AppPermissions.Pages_Cities_Delete, L("DeleteCity"), multiTenancySides: MultiTenancySides.Tenant);



            pages.CreateChildPermission(AppPermissions.Pages_DemoUiComponents, L("DemoUiComponents"));

            var administration = pages.CreateChildPermission(AppPermissions.Pages_Administration, L("Administration"));

            var roles = administration.CreateChildPermission(AppPermissions.Pages_Administration_Roles, L("Roles"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Create, L("CreatingNewRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Edit, L("EditingRole"));
            roles.CreateChildPermission(AppPermissions.Pages_Administration_Roles_Delete, L("DeletingRole"));

            var users = administration.CreateChildPermission(AppPermissions.Pages_Administration_Users, L("Users"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Create, L("CreatingNewUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Edit, L("EditingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Delete, L("DeletingUser"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_ChangePermissions, L("ChangingPermissions"));
            users.CreateChildPermission(AppPermissions.Pages_Administration_Users_Impersonation, L("LoginForUsers"));

            var languages = administration.CreateChildPermission(AppPermissions.Pages_Administration_Languages, L("Languages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Create, L("CreatingNewLanguage"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Edit, L("EditingLanguage"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_Delete, L("DeletingLanguages"));
            languages.CreateChildPermission(AppPermissions.Pages_Administration_Languages_ChangeTexts, L("ChangingTexts"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_AuditLogs, L("AuditLogs"));

            var organizationUnits = administration.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits, L("OrganizationUnits"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageOrganizationTree, L("ManagingOrganizationTree"));
            organizationUnits.CreateChildPermission(AppPermissions.Pages_Administration_OrganizationUnits_ManageMembers, L("ManagingMembers"));

            administration.CreateChildPermission(AppPermissions.Pages_Administration_UiCustomization, L("VisualSettings"));

            //TENANT-SPECIFIC PERMISSIONS

            pages.CreateChildPermission(AppPermissions.Pages_Tenant_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Tenant);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Tenant_SubscriptionManagement, L("Subscription"), multiTenancySides: MultiTenancySides.Tenant);

            //HOST-SPECIFIC PERMISSIONS

            var editions = pages.CreateChildPermission(AppPermissions.Pages_Editions, L("Editions"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Create, L("CreatingNewEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Edit, L("EditingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_Delete, L("DeletingEdition"), multiTenancySides: MultiTenancySides.Host);
            editions.CreateChildPermission(AppPermissions.Pages_Editions_MoveTenantsToAnotherEdition, L("MoveTenantsToAnotherEdition"), multiTenancySides: MultiTenancySides.Host); 

            var tenants = pages.CreateChildPermission(AppPermissions.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Create, L("CreatingNewTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Edit, L("EditingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_ChangeFeatures, L("ChangingFeatures"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Delete, L("DeletingTenant"), multiTenancySides: MultiTenancySides.Host);
            tenants.CreateChildPermission(AppPermissions.Pages_Tenants_Impersonation, L("LoginForTenants"), multiTenancySides: MultiTenancySides.Host);

            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Settings, L("Settings"), multiTenancySides: MultiTenancySides.Host);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Maintenance, L("Maintenance"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_HangfireDashboard, L("HangfireDashboard"), multiTenancySides: _isMultiTenancyEnabled ? MultiTenancySides.Host : MultiTenancySides.Tenant);
            administration.CreateChildPermission(AppPermissions.Pages_Administration_Host_Dashboard, L("Dashboard"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlatformMysqlConsts.LocalizationSourceName);
        }
    }
}
