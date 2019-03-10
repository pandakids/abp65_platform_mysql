using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Ancestor
{
    public interface IForeFathersAppService : IApplicationService 
    {
        Task<PagedResultDto<GetForeFatherForView>> GetAll(GetAllForeFathersInput input);

		Task<GetForeFatherForEditOutput> GetForeFatherForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditForeFatherDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetForeFathersToExcel(GetAllForeFathersForExcelInput input);

		
		Task<PagedResultDto<BinaryObjectLookupTableDto>> GetAllBinaryObjectForLookupTable(GetAllForLookupTableInput input);
		
		Task<PagedResultDto<TempleLookupTableDto>> GetAllTempleForLookupTable(GetAllForLookupTableInput input);

        /// <summary>
        /// 重新设置先祖GPS定位
        /// 宗堂管理员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task ReSetPosition(ReSetPositionInput input);
    }
}