using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Ancestor
{
    public interface ITemplesAppService : IApplicationService 
    {
        Task<PagedResultDto<GetTempleForView>> GetAll(GetAllTemplesInput input);

		Task<GetTempleForEditOutput> GetTempleForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditTempleDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetTemplesToExcel(GetAllTemplesForExcelInput input);

		
		Task<PagedResultDto<BinaryObjectLookupTableDto>> GetAllBinaryObjectForLookupTable(GetAllForLookupTableInput input);
		
		Task<PagedResultDto<UserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input);
		
		Task<PagedResultDto<CityLookupTableDto>> GetAllCityForLookupTable(GetAllForLookupTableInput input);
		
    }
}