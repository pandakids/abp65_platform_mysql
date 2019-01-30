namespace Hoooten.PlatformMysql.Auditing
{
    public interface INamespaceStripper
    {
        string StripNameSpace(string serviceName);
    }
}