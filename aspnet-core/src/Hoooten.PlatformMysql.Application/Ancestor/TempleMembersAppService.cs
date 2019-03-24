using Hoooten.PlatformMysql.Authorization.Users;
using Hoooten.PlatformMysql.Ancestor;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Hoooten.PlatformMysql.Ancestor.Exporting;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Authorization;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;
using Abp.Runtime.Session;
using Abp.UI;

namespace Hoooten.PlatformMysql.Ancestor
{
    [AbpAuthorize(AppPermissions.Pages_TempleMembers)]
    public class TempleMembersAppService : PlatformMysqlAppServiceBase, ITempleMembersAppService
    {
        private readonly IRepository<TempleMember> _templeMemberRepository;
        private readonly ITempleMembersExcelExporter _templeMembersExcelExporter;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Temple, int> _templeRepository;


        public TempleMembersAppService(IRepository<TempleMember> templeMemberRepository, ITempleMembersExcelExporter templeMembersExcelExporter, IRepository<User, long> userRepository, IRepository<Temple, int> templeRepository)
        {
            _templeMemberRepository = templeMemberRepository;
            _templeMembersExcelExporter = templeMembersExcelExporter;
            _userRepository = userRepository;
            _templeRepository = templeRepository;

        }

        public async Task<PagedResultDto<GetTempleMemberForView>> GetAll(GetAllTempleMembersInput input)
        {

            var filteredTempleMembers = _templeMemberRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Marks.Contains(input.Filter))
                        .WhereIf(input.IsApprovedFilter.HasValue , e => Convert.ToInt32(e.IsApproved) == input.IsApprovedFilter)
                        .Where(e => input.TempleId == e.TempleId);


            var query = (from o in filteredTempleMembers
                         join o1 in _userRepository.GetAll() on o.UserId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         join o2 in _templeRepository.GetAll() on o.TempleId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()

                         select new GetTempleMemberForView()
                         {
                             TempleMember = ObjectMapper.Map<TempleMemberDto>(o),
                             UserName = s1 == null ? "" : s1.Name.ToString(),//成员姓名
                             RealName = s1.Surname,
                             Sexy = s1.Sexy,
                             TempleName = s2 == null ? "" : s2.Name.ToString(),//宗堂名称
                             Century = s1.Century,
                             PhoneNumber = s1.PhoneNumber
                         })

                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserName.ToLower() == input.UserNameFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TempleNameFilter), e => e.TempleName.ToLower() == input.TempleNameFilter.ToLower().Trim());

            var totalCount = await query.CountAsync();

            var templeMembers = await query
                .OrderBy(input.Sorting ?? "templeMember.id asc")
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetTempleMemberForView>(
                totalCount,
                templeMembers
            );
        }

        [AbpAuthorize(AppPermissions.Pages_TempleMembers_Edit)]
        public async Task<GetTempleMemberForEditOutput> GetTempleMemberForEdit(EntityDto input)
        {
            var templeMember = await _templeMemberRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetTempleMemberForEditOutput { TempleMember = ObjectMapper.Map<CreateOrEditTempleMemberDto>(templeMember) };

            if (output.TempleMember.UserId != null)
            {
                var user = await _userRepository.FirstOrDefaultAsync((long)output.TempleMember.UserId);
                output.UserName = user.Name.ToString();
            }
            if (output.TempleMember.TempleId != null)
            {
                var temple = await _templeRepository.FirstOrDefaultAsync((int)output.TempleMember.TempleId);
                output.TempleName = temple.Name.ToString();
            }


            return output;
        }

        /// <summary>
        /// 加入宗堂
        /// 1 需宗堂管理员进行审核
        /// 2 奖励纸钱，元宝
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrEdit(CreateOrEditTempleMemberDto input)
        {
            if (input.Id == null)
            {
                await Create(input);
            }
            else
            {
                await Update(input);
            }
        }

        public async Task Approve(CreateOrEditTempleMemberDto input)
        {
            var templeMember = await _templeMemberRepository.FirstOrDefaultAsync((int)input.Id);
            templeMember.IsApproved = true;
        }

        [AbpAuthorize(AppPermissions.Pages_TempleMembers_Create)]
        private async Task Create(CreateOrEditTempleMemberDto input)
        {
            var userId = AbpSession.GetUserId();
            if (!input.UserId.HasValue)
            {
                input.UserId = userId;
            }

            var count = _templeMemberRepository.GetAll().Where(e=>e.UserId == userId && e.TempleId == input.TempleId);
            if (count.Any())
            {
                throw new UserFriendlyException(L("AlreadyJoinInTempleWarning"));
            }

            var templeMember = ObjectMapper.Map<TempleMember>(input);



            await _templeMemberRepository.InsertAsync(templeMember);
        }

        [AbpAuthorize(AppPermissions.Pages_TempleMembers_Edit)]
        private async Task Update(CreateOrEditTempleMemberDto input)
        {
            var templeMember = await _templeMemberRepository.FirstOrDefaultAsync((int)input.Id);
            ObjectMapper.Map(input, templeMember);
        }

        [AbpAuthorize(AppPermissions.Pages_TempleMembers_Delete)]
        public async Task Delete(EntityDto input)
        {
            await _templeMemberRepository.DeleteAsync(input.Id);
        }

        public async Task<FileDto> GetTempleMembersToExcel(GetAllTempleMembersForExcelInput input)
        {

            var filteredTempleMembers = _templeMemberRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Marks.Contains(input.Filter))
                        .WhereIf(input.IsApprovedFilter > -1, e => Convert.ToInt32(e.IsApproved) == input.IsApprovedFilter);


            var query = (from o in filteredTempleMembers
                         join o1 in _userRepository.GetAll() on o.UserId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         join o2 in _templeRepository.GetAll() on o.TempleId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()

                         select new GetTempleMemberForView()
                         {
                             TempleMember = ObjectMapper.Map<TempleMemberDto>(o)
                         ,
                             UserName = s1 == null ? "" : s1.Name.ToString()
                    ,
                             TempleName = s2 == null ? "" : s2.Name.ToString()

                         })

                        .WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserName.ToLower() == input.UserNameFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.TempleNameFilter), e => e.TempleName.ToLower() == input.TempleNameFilter.ToLower().Trim());


            var TempleMemberListDtos = await query.ToListAsync();

            return _templeMembersExcelExporter.ExportToFile(TempleMemberListDtos);
        }

        [AbpAuthorize(AppPermissions.Pages_TempleMembers)]
        public async Task<PagedResultDto<UserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _userRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Name.ToString().Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var userList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<UserLookupTableDto>();
            foreach (var user in userList)
            {
                lookupTableDtoList.Add(new UserLookupTableDto
                {
                    Id = user.Id,
                    DisplayName = user.Name.ToString()
                });
            }

            return new PagedResultDto<UserLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }
        [AbpAuthorize(AppPermissions.Pages_TempleMembers)]
        public async Task<PagedResultDto<TempleLookupTableDto>> GetAllTempleForLookupTable(GetAllForLookupTableInput input)
        {
            var query = _templeRepository.GetAll().WhereIf(
                   !string.IsNullOrWhiteSpace(input.Filter),
                  e => e.Name.ToString().Contains(input.Filter)
               );

            var totalCount = await query.CountAsync();

            var templeList = await query
                .PageBy(input)
                .ToListAsync();

            var lookupTableDtoList = new List<TempleLookupTableDto>();
            foreach (var temple in templeList)
            {
                lookupTableDtoList.Add(new TempleLookupTableDto
                {
                    Id = temple.Id,
                    DisplayName = temple.Name.ToString()
                });
            }

            return new PagedResultDto<TempleLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
        }

        public Task<PagedResultDto<GetTempleMemberForView>> GetAllByTempleId(GetAllTempleMembersByTempleIdInput input)
        {
            throw new NotImplementedException();
        }
    }
}