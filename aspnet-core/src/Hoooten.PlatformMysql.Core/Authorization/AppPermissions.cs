namespace Hoooten.PlatformMysql.Authorization
{
    /// <summary>
    /// Defines string constants for application's permission names.
    /// <see cref="AppAuthorizationProvider"/> for permission definitions.
    /// </summary>
    public static class AppPermissions
    {
        public const string Pages_ForeActivities = "Pages.ForeActivities";
        public const string Pages_ForeActivities_Create = "Pages.ForeActivities.Create";
        public const string Pages_ForeActivities_Edit = "Pages.ForeActivities.Edit";
        public const string Pages_ForeActivities_Delete = "Pages.ForeActivities.Delete";

        public const string Pages_UserGifts = "Pages.UserGifts";
        public const string Pages_UserGifts_Create = "Pages.UserGifts.Create";
        public const string Pages_UserGifts_Edit = "Pages.UserGifts.Edit";
        public const string Pages_UserGifts_Delete = "Pages.UserGifts.Delete";

        public const string Pages_ForeFatherGifts = "Pages.ForeFatherGifts";
        public const string Pages_ForeFatherGifts_Create = "Pages.ForeFatherGifts.Create";
        public const string Pages_ForeFatherGifts_Edit = "Pages.ForeFatherGifts.Edit";
        public const string Pages_ForeFatherGifts_Delete = "Pages.ForeFatherGifts.Delete";

        public const string Pages_ForeFathers = "Pages.ForeFathers";
        public const string Pages_ForeFathers_Create = "Pages.ForeFathers.Create";
        public const string Pages_ForeFathers_Edit = "Pages.ForeFathers.Edit";
        public const string Pages_ForeFathers_Delete = "Pages.ForeFathers.Delete";

        public const string Pages_TempleMembers = "Pages.TempleMembers";
        public const string Pages_TempleMembers_Create = "Pages.TempleMembers.Create";
        public const string Pages_TempleMembers_Edit = "Pages.TempleMembers.Edit";
        public const string Pages_TempleMembers_Delete = "Pages.TempleMembers.Delete";

        public const string Pages_Temples = "Pages.Temples";
        public const string Pages_Temples_Create = "Pages.Temples.Create";
        public const string Pages_Temples_Edit = "Pages.Temples.Edit";
        public const string Pages_Temples_Delete = "Pages.Temples.Delete";

        public const string Pages_Cities = "Pages.Cities";
        public const string Pages_Cities_Create = "Pages.Cities.Create";
        public const string Pages_Cities_Edit = "Pages.Cities.Edit";
        public const string Pages_Cities_Delete = "Pages.Cities.Delete";

        //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

        public const string Pages = "Pages";

        public const string Pages_DemoUiComponents= "Pages.DemoUiComponents";
        public const string Pages_Administration = "Pages.Administration";

        public const string Pages_Administration_Roles = "Pages.Administration.Roles";
        public const string Pages_Administration_Roles_Create = "Pages.Administration.Roles.Create";
        public const string Pages_Administration_Roles_Edit = "Pages.Administration.Roles.Edit";
        public const string Pages_Administration_Roles_Delete = "Pages.Administration.Roles.Delete";

        public const string Pages_Administration_Users = "Pages.Administration.Users";
        public const string Pages_Administration_Users_Create = "Pages.Administration.Users.Create";
        public const string Pages_Administration_Users_Edit = "Pages.Administration.Users.Edit";
        public const string Pages_Administration_Users_Delete = "Pages.Administration.Users.Delete";
        public const string Pages_Administration_Users_ChangePermissions = "Pages.Administration.Users.ChangePermissions";
        public const string Pages_Administration_Users_Impersonation = "Pages.Administration.Users.Impersonation";

        public const string Pages_Administration_Languages = "Pages.Administration.Languages";
        public const string Pages_Administration_Languages_Create = "Pages.Administration.Languages.Create";
        public const string Pages_Administration_Languages_Edit = "Pages.Administration.Languages.Edit";
        public const string Pages_Administration_Languages_Delete = "Pages.Administration.Languages.Delete";
        public const string Pages_Administration_Languages_ChangeTexts = "Pages.Administration.Languages.ChangeTexts";

        public const string Pages_Administration_AuditLogs = "Pages.Administration.AuditLogs";

        public const string Pages_Administration_OrganizationUnits = "Pages.Administration.OrganizationUnits";
        public const string Pages_Administration_OrganizationUnits_ManageOrganizationTree = "Pages.Administration.OrganizationUnits.ManageOrganizationTree";
        public const string Pages_Administration_OrganizationUnits_ManageMembers = "Pages.Administration.OrganizationUnits.ManageMembers";

        public const string Pages_Administration_HangfireDashboard = "Pages.Administration.HangfireDashboard";

        public const string Pages_Administration_UiCustomization = "Pages.Administration.UiCustomization";

        //TENANT-SPECIFIC PERMISSIONS

        public const string Pages_Tenant_Dashboard = "Pages.Tenant.Dashboard";

        public const string Pages_Administration_Tenant_Settings = "Pages.Administration.Tenant.Settings";

        public const string Pages_Administration_Tenant_SubscriptionManagement = "Pages.Administration.Tenant.SubscriptionManagement";

        //HOST-SPECIFIC PERMISSIONS

        public const string Pages_Editions = "Pages.Editions";
        public const string Pages_Editions_Create = "Pages.Editions.Create";
        public const string Pages_Editions_Edit = "Pages.Editions.Edit";
        public const string Pages_Editions_Delete = "Pages.Editions.Delete";
        public const string Pages_Editions_MoveTenantsToAnotherEdition = "Pages.Editions.MoveTenantsToAnotherEdition";

        public const string Pages_Tenants = "Pages.Tenants";
        public const string Pages_Tenants_Create = "Pages.Tenants.Create";
        public const string Pages_Tenants_Edit = "Pages.Tenants.Edit";
        public const string Pages_Tenants_ChangeFeatures = "Pages.Tenants.ChangeFeatures";
        public const string Pages_Tenants_Delete = "Pages.Tenants.Delete";
        public const string Pages_Tenants_Impersonation = "Pages.Tenants.Impersonation";

        public const string Pages_Administration_Host_Maintenance = "Pages.Administration.Host.Maintenance";
        public const string Pages_Administration_Host_Settings = "Pages.Administration.Host.Settings";
        public const string Pages_Administration_Host_Dashboard = "Pages.Administration.Host.Dashboard";

    }
}