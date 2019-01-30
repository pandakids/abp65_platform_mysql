using Xamarin.Forms.Internals;

namespace Hoooten.PlatformMysql.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}