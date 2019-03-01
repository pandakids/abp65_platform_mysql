using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Ancestor
{
    public interface IForeFatherGiftsAppService : IApplicationService 
    {
        Task<PagedResultDto<GetForeFatherGiftForView>> GetAll(GetAllForeFatherGiftsInput input);

		Task<GetForeFatherGiftForEditOutput> GetForeFatherGiftForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditForeFatherGiftDto input);

		Task Delete(EntityDto input);

		
		Task<PagedResultDto<ForeFatherLookupTableDto>> GetAllForeFatherForLookupTable(GetAllForLookupTableInput input);
		
		Task<PagedResultDto<UserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input);

        /// <summary>
        /// Ð¢ÐÄ²Ù×÷
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task SendGift(SendGiftInput input);
    }
}