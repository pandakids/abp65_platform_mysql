using System.Threading.Tasks;
using Abp.Dependency;

namespace Hoooten.PlatformMysql.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}