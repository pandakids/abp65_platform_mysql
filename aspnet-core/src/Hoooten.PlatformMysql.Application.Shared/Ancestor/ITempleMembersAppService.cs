using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Ancestor
{
    public interface ITempleMembersAppService : IApplicationService 
    {
        Task<PagedResultDto<GetTempleMemberForView>> GetAll(GetAllTempleMembersInput input);

		Task<GetTempleMemberForEditOutput> GetTempleMemberForEdit(EntityDto input);

		Task CreateOrEdit(CreateOrEditTempleMemberDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetTempleMembersToExcel(GetAllTempleMembersForExcelInput input);

		
		Task<PagedResultDto<UserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input);
		
		Task<PagedResultDto<TempleLookupTableDto>> GetAllTempleForLookupTable(GetAllForLookupTableInput input);

        /// <summary>
        /// 根据宗堂获取所有的成员
        /// </summary>
        /// <param name="templeId"></param>
        /// <returns></returns>
        Task<PagedResultDto<GetTempleMemberForView>> GetAllByTempleId(GetAllTempleMembersByTempleIdInput input);
        Task Approve(CreateOrEditTempleMemberDto createOrEditTempleMemberDto);
    }
}