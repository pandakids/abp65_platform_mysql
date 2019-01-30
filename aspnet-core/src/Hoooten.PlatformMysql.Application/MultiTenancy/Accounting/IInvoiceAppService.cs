using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.MultiTenancy.Accounting.Dto;

namespace Hoooten.PlatformMysql.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
