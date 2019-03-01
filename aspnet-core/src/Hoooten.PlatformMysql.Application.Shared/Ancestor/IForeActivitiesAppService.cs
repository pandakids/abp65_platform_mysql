using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Ancestor
{
    public interface IForeActivitiesAppService : IApplicationService 
    {
        Task<PagedResultDto<GetForeActivityForView>> GetAll(GetAllForeActivitiesInput input);

		Task<GetForeActivityForEditOutput> GetForeActivityForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditForeActivityDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetForeActivitiesToExcel(GetAllForeActivitiesForExcelInput input);

		
		Task<PagedResultDto<BinaryObjectLookupTableDto>> GetAllBinaryObjectForLookupTable(GetAllForLookupTableInput input);
		
		Task<PagedResultDto<TempleLookupTableDto>> GetAllTempleForLookupTable(GetAllForLookupTableInput input);
		
    }
}