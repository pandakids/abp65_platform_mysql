using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Ancestor
{
    public interface ICitiesAppService : IApplicationService 
    {
        Task<PagedResultDto<GetCityForView>> GetAll(GetAllCitiesInput input);

		Task<GetCityForEditOutput> GetCityForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditCityDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetCitiesToExcel(GetAllCitiesForExcelInput input);

		
    }
}