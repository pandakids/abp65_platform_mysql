using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Ancestor
{
    public interface IUserGiftsAppService : IApplicationService 
    {
        Task<PagedResultDto<GetUserGiftForView>> GetAll(GetAllUserGiftsInput input);

		Task<GetUserGiftForEditOutput> GetUserGiftForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditUserGiftDto input);

		Task Delete(EntityDto input);

		
		Task<PagedResultDto<UserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input);
		
    }
}