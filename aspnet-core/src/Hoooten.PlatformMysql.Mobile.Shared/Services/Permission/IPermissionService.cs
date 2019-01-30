namespace Hoooten.PlatformMysql.Services.Permission
{
    public interface IPermissionService
    {
        bool HasPermission(string key);
    }
}