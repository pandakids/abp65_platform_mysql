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
        /// �½�����
        /// 1 ���� �����·����ʻ���ֽǮ��Ԫ��
        /// 2 ���˳�Ϊ���ù���Ա
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
        /// ��˼�������
        /// </summary>
        /// <param name="approveJoinIn"></param>
        /// <returns></returns>
        Task ApproveJoinInMember(ApproveJoinInMemberInput approveJoinIn);

        /// <summary>
        /// �˳�����
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task LeaveTemple(EntityDto input);

        /// <summary>
        /// �ƽ����ù���Ա
        /// </summary>
        /// <param name="changeTemple"></param>
        /// <returns></returns>
        Task ChangeTempleMasterRole(ChangeTempleMasterRoleInput changeTemple);
    }
}