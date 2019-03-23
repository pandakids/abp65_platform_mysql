using Hoooten.PlatformMysql.Storage;
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
using Hoooten.PlatformMysql.Authorization.Users;
using Abp.UI;

namespace Hoooten.PlatformMysql.Ancestor
{
	[AbpAuthorize(AppPermissions.Pages_ForeFathers)]
    public class ForeFathersAppService : PlatformMysqlAppServiceBase, IForeFathersAppService
    {
		 private readonly IRepository<ForeFather> _foreFatherRepository;
		 private readonly IForeFathersExcelExporter _foreFathersExcelExporter;
		 private readonly IRepository<BinaryObject,Guid> _binaryObjectRepository;
		 private readonly IRepository<Temple,int> _templeRepository;
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<TempleMember> _templeMemberRepository;

        public ForeFathersAppService(IRepository<ForeFather> foreFatherRepository, IRepository<User, long> userRepository, IForeFathersExcelExporter foreFathersExcelExporter , IRepository<BinaryObject, Guid> binaryObjectRepository, IRepository<Temple, int> templeRepository, IRepository<TempleMember> templeMemberRepository) 
		  {
			_foreFatherRepository = foreFatherRepository;
			_foreFathersExcelExporter = foreFathersExcelExporter;
			_binaryObjectRepository = binaryObjectRepository;
		_templeRepository = templeRepository;
            _userRepository = userRepository;
            _templeMemberRepository = templeMemberRepository;
        }

		 public async Task<PagedResultDto<GetForeFatherForView>> GetAll(GetAllForeFathersInput input)
         {
            //判断是否已经加入宗堂
            var userId = AbpSession.UserId.Value;
            var currentUser = _templeMemberRepository.GetAll().Where(e => e.UserId == userId);
            if (!currentUser.Any()) {
                throw new UserFriendlyException(L("NotJoinInTempleWarning"));
            }
            var templeId = currentUser.FirstOrDefault().TempleId;

            var filteredForeFathers = _foreFatherRepository.GetAll()
                        .WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false || e.Name.Contains(input.Filter) || e.Century.Contains(input.Filter) || e.Marks.Contains(input.Filter))
                        .WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter), e => e.Name.ToLower() == input.NameFilter.ToLower().Trim())
                        .WhereIf(!string.IsNullOrWhiteSpace(input.CenturyFilter), e => e.Century.ToLower() == input.CenturyFilter.ToLower().Trim())
                        .Where(e=> e.TempleId == templeId);


			var query = (from o in filteredForeFathers
                         join o1 in _binaryObjectRepository.GetAll() on o.BinaryObjectId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         join o2 in _templeRepository.GetAll() on o.TempleId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()
                         
                         select new GetForeFatherForView() { ForeFather = ObjectMapper.Map<ForeFatherDto>(o)
						 , BinaryObjectTenantId = s1 == null ? "" : s1.TenantId.ToString()
					, TempleName = s2 == null ? "" : s2.Name.ToString()
					
						 })
						 
						.WhereIf(!string.IsNullOrWhiteSpace(input.BinaryObjectTenantIdFilter), e => e.BinaryObjectTenantId.ToLower() == input.BinaryObjectTenantIdFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.TempleNameFilter), e => e.TempleName.ToLower() == input.TempleNameFilter.ToLower().Trim());

            var totalCount = await query.CountAsync();

            var foreFathers = await query
                .OrderBy(input.Sorting ?? "foreFather.id asc")
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetForeFatherForView>(
                totalCount,
                foreFathers
            );
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_ForeFathers_Edit)]
		 public async Task<GetForeFatherForEditOutput> GetForeFatherForEdit(EntityDto input)
         {
            var foreFather = await _foreFatherRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetForeFatherForEditOutput {ForeFather = ObjectMapper.Map<CreateOrEditForeFatherDto>(foreFather)};

			if (output.ForeFather.BinaryObjectId != null)
            {
                var binaryObject = await _binaryObjectRepository.FirstOrDefaultAsync((Guid)output.ForeFather.BinaryObjectId);
                output.BinaryObjectTenantId = binaryObject.TenantId.ToString();
            }
			if (foreFather.TempleId.HasValue)
            {
                var temple = await _templeRepository.FirstOrDefaultAsync(foreFather.TempleId.Value);
                output.TempleName = temple.Name.ToString();
            }
			
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditForeFatherDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_ForeFathers_Create)]
		 private async Task Create(CreateOrEditForeFatherDto input)
         {
            //判断是否已经加入宗堂
            var userId = AbpSession.UserId.Value;
            var currentUser = _templeMemberRepository.GetAll().Where(e => e.UserId == userId);
            if (!currentUser.Any())
            {
                throw new UserFriendlyException(L("NotJoinInTempleWarning"));
            }
            var templeId = currentUser.FirstOrDefault().TempleId;

            //input.TempleId = templeId;

            var foreFather = ObjectMapper.Map<ForeFather>(input);
            foreFather.TempleId = templeId;

            await _foreFatherRepository.InsertAsync(foreFather);
         }

		 [AbpAuthorize(AppPermissions.Pages_ForeFathers_Edit)]
		 private async Task Update(CreateOrEditForeFatherDto input)
         {
            var foreFather = await _foreFatherRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, foreFather);
         }

		 [AbpAuthorize(AppPermissions.Pages_ForeFathers_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _foreFatherRepository.DeleteAsync(input.Id);
         }

		 public async Task<FileDto> GetForeFathersToExcel(GetAllForeFathersForExcelInput input)
         {

			var filteredForeFathers = _foreFatherRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter) || e.Century.Contains(input.Filter) || e.Marks.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name.ToLower() == input.NameFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.CenturyFilter),  e => e.Century.ToLower() == input.CenturyFilter.ToLower().Trim());


			var query = (from o in filteredForeFathers
                         join o1 in _binaryObjectRepository.GetAll() on o.BinaryObjectId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         join o2 in _templeRepository.GetAll() on o.TempleId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()
                         
                         select new GetForeFatherForView() { ForeFather = ObjectMapper.Map<ForeFatherDto>(o)
						 , BinaryObjectTenantId = s1 == null ? "" : s1.TenantId.ToString()
					, TempleName = s2 == null ? "" : s2.Name.ToString()
					
						 })
						 
						.WhereIf(!string.IsNullOrWhiteSpace(input.BinaryObjectTenantIdFilter), e => e.BinaryObjectTenantId.ToLower() == input.BinaryObjectTenantIdFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.TempleNameFilter), e => e.TempleName.ToLower() == input.TempleNameFilter.ToLower().Trim());


            var ForeFatherListDtos = await query.ToListAsync();

            return _foreFathersExcelExporter.ExportToFile(ForeFatherListDtos);
         }

		 [AbpAuthorize(AppPermissions.Pages_ForeFathers)]
         public async Task<PagedResultDto<BinaryObjectLookupTableDto>> GetAllBinaryObjectForLookupTable(GetAllForLookupTableInput input)
         {
             var query = _binaryObjectRepository.GetAll().WhereIf(
                    !string.IsNullOrWhiteSpace(input.Filter),
                   e=> e.TenantId.ToString().Contains(input.Filter)
                );

            var totalCount = await query.CountAsync();

            var binaryObjectList = await query
                .PageBy(input)
                .ToListAsync();

			var lookupTableDtoList = new List<BinaryObjectLookupTableDto>();
			foreach(var binaryObject in binaryObjectList){
				lookupTableDtoList.Add(new BinaryObjectLookupTableDto
				{
					Id = binaryObject.Id.ToString(),
					DisplayName = binaryObject.TenantId.ToString()
				});
			}

            return new PagedResultDto<BinaryObjectLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
         }		 [AbpAuthorize(AppPermissions.Pages_ForeFathers)]
         public async Task<PagedResultDto<TempleLookupTableDto>> GetAllTempleForLookupTable(GetAllForLookupTableInput input)
         {
             var query = _templeRepository.GetAll().WhereIf(
                    !string.IsNullOrWhiteSpace(input.Filter),
                   e=> e.Name.ToString().Contains(input.Filter)
                );

            var totalCount = await query.CountAsync();

            var templeList = await query
                .PageBy(input)
                .ToListAsync();

			var lookupTableDtoList = new List<TempleLookupTableDto>();
			foreach(var temple in templeList){
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

        public Task ReSetPosition(ReSetPositionInput input)
        {
            throw new NotImplementedException();
        }
    }
}