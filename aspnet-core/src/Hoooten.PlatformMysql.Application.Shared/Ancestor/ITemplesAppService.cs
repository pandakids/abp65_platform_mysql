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

        /// <summary>
        /// 新建宗堂
        /// 1 奖励 车，衣服，鲜花，纸钱，元宝
        /// 2 本人成为宗堂管理员
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
		Task CreateOrEdit(CreateOrEditTempleDto input);

		Task Delete(EntityDto input);

		Task<FileDto> GetTemplesToExcel(GetAllTemplesForExcelInput input);

		
		Task<PagedResultDto<BinaryObjectLookupTableDto>> GetAllBinaryObjectForLookupTable(GetAllForLookupTableInput input);
		
		Task<PagedResultDto<UserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input);
		
		Task<PagedResultDto<CityLookupTableDto>> GetAllCityForLookupTable(GetAllForLookupTableInput input);


        /// <summary>
        /// 审核加入宗堂
        /// </summary>
        /// <param name="approveJoinIn"></param>
        /// <returns></returns>
        Task ApproveJoinInMember(ApproveJoinInMemberInput approveJoinIn);

        /// <summary>
        /// 退出宗堂
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task LeaveTemple(EntityDto input);

        /// <summary>
        /// 移交宗堂管理员
        /// </summary>
        /// <param name="changeTemple"></param>
        /// <returns></returns>
        Task ChangeTempleMasterRole(ChangeTempleMasterRoleInput changeTemple);
    }
}