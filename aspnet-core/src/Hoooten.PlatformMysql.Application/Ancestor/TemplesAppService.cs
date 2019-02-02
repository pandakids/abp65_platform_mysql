using Hoooten.PlatformMysql.Storage;
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

namespace Hoooten.PlatformMysql.Ancestor
{
	[AbpAuthorize(AppPermissions.Pages_Temples)]
    public class TemplesAppService : PlatformMysqlAppServiceBase, ITemplesAppService
    {
		 private readonly IRepository<Temple> _templeRepository;
		 private readonly ITemplesExcelExporter _templesExcelExporter;
		 private readonly IRepository<BinaryObject,Guid> _binaryObjectRepository;
		 private readonly IRepository<User,long> _userRepository;
		 private readonly IRepository<City,int> _cityRepository;
		 

		  public TemplesAppService(IRepository<Temple> templeRepository, ITemplesExcelExporter templesExcelExporter , IRepository<BinaryObject, Guid> binaryObjectRepository, IRepository<User, long> userRepository, IRepository<City, int> cityRepository) 
		  {
			_templeRepository = templeRepository;
			_templesExcelExporter = templesExcelExporter;
			_binaryObjectRepository = binaryObjectRepository;
		_userRepository = userRepository;
		_cityRepository = cityRepository;
		
		  }

		 public async Task<PagedResultDto<GetTempleForView>> GetAll(GetAllTemplesInput input)
         {

			var filteredTemples = _templeRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter) || e.Code.Contains(input.Filter) || e.FanmilyName.Contains(input.Filter) || e.Address.Contains(input.Filter) || e.Photo.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name.ToLower() == input.NameFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.FanmilyNameFilter),  e => e.FanmilyName.ToLower() == input.FanmilyNameFilter.ToLower().Trim())
						.WhereIf(input.IsShowFilter > -1,  e => Convert.ToInt32(e.IsShow) == input.IsShowFilter );


			var query = (from o in filteredTemples
                         join o1 in _binaryObjectRepository.GetAll() on o.BinaryObjectId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         join o2 in _userRepository.GetAll() on o.UserId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()
                         join o3 in _cityRepository.GetAll() on o.CityId equals o3.Id into j3
                         from s3 in j3.DefaultIfEmpty()
                         
                         select new GetTempleForView() { Temple = ObjectMapper.Map<TempleDto>(o)
						 , BinaryObjectBytes = s1 == null ? "" : s1.Bytes.ToString()
					, UserName = s2 == null ? "" : s2.Name.ToString()
					, Citycid = s3 == null ? "" : s3.cid.ToString()
					
						 })
						 
						.WhereIf(!string.IsNullOrWhiteSpace(input.BinaryObjectBytesFilter), e => e.BinaryObjectBytes.ToLower() == input.BinaryObjectBytesFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserName.ToLower() == input.UserNameFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.CitycidFilter), e => e.Citycid.ToLower() == input.CitycidFilter.ToLower().Trim());

            var totalCount = await query.CountAsync();

            var temples = await query
                .OrderBy(input.Sorting ?? "temple.id asc")
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetTempleForView>(
                totalCount,
                temples
            );
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_Temples_Edit)]
		 public async Task<GetTempleForEditOutput> GetTempleForEdit(EntityDto input)
         {
            var temple = await _templeRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetTempleForEditOutput {Temple = ObjectMapper.Map<CreateOrEditTempleDto>(temple)};

			if (output.Temple.BinaryObjectId != null)
            {
                var binaryObject = await _binaryObjectRepository.FirstOrDefaultAsync((Guid)output.Temple.BinaryObjectId);
                output.BinaryObjectBytes = binaryObject.Bytes.ToString();
            }
			if (output.Temple.UserId != null)
            {
                var user = await _userRepository.FirstOrDefaultAsync((long)output.Temple.UserId);
                output.UserName = user.Name.ToString();
            }
			if (output.Temple.CityId != null)
            {
                var city = await _cityRepository.FirstOrDefaultAsync((int)output.Temple.CityId);
                output.Citycid = city.cid.ToString();
            }
			
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditTempleDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_Temples_Create)]
		 private async Task Create(CreateOrEditTempleDto input)
         {
            var temple = ObjectMapper.Map<Temple>(input);

			

            await _templeRepository.InsertAsync(temple);
         }

		 [AbpAuthorize(AppPermissions.Pages_Temples_Edit)]
		 private async Task Update(CreateOrEditTempleDto input)
         {
            var temple = await _templeRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, temple);
         }

		 [AbpAuthorize(AppPermissions.Pages_Temples_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _templeRepository.DeleteAsync(input.Id);
         }

		 public async Task<FileDto> GetTemplesToExcel(GetAllTemplesForExcelInput input)
         {

			var filteredTemples = _templeRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter) || e.Code.Contains(input.Filter) || e.FanmilyName.Contains(input.Filter) || e.Address.Contains(input.Filter) || e.Photo.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name.ToLower() == input.NameFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.FanmilyNameFilter),  e => e.FanmilyName.ToLower() == input.FanmilyNameFilter.ToLower().Trim())
						.WhereIf(input.IsShowFilter > -1,  e => Convert.ToInt32(e.IsShow) == input.IsShowFilter );


			var query = (from o in filteredTemples
                         join o1 in _binaryObjectRepository.GetAll() on o.BinaryObjectId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         join o2 in _userRepository.GetAll() on o.UserId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()
                         join o3 in _cityRepository.GetAll() on o.CityId equals o3.Id into j3
                         from s3 in j3.DefaultIfEmpty()
                         
                         select new GetTempleForView() { Temple = ObjectMapper.Map<TempleDto>(o)
						 , BinaryObjectBytes = s1 == null ? "" : s1.Bytes.ToString()
					, UserName = s2 == null ? "" : s2.Name.ToString()
					, Citycid = s3 == null ? "" : s3.cid.ToString()
					
						 })
						 
						.WhereIf(!string.IsNullOrWhiteSpace(input.BinaryObjectBytesFilter), e => e.BinaryObjectBytes.ToLower() == input.BinaryObjectBytesFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserName.ToLower() == input.UserNameFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.CitycidFilter), e => e.Citycid.ToLower() == input.CitycidFilter.ToLower().Trim());


            var TempleListDtos = await query.ToListAsync();

            return _templesExcelExporter.ExportToFile(TempleListDtos);
         }

		 [AbpAuthorize(AppPermissions.Pages_Temples)]
         public async Task<PagedResultDto<BinaryObjectLookupTableDto>> GetAllBinaryObjectForLookupTable(GetAllForLookupTableInput input)
         {
             var query = _binaryObjectRepository.GetAll().WhereIf(
                    !string.IsNullOrWhiteSpace(input.Filter),
                   e=> e.Bytes.ToString().Contains(input.Filter)
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
					DisplayName = binaryObject.Bytes.ToString()
				});
			}

            return new PagedResultDto<BinaryObjectLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
         }		 [AbpAuthorize(AppPermissions.Pages_Temples)]
         public async Task<PagedResultDto<UserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input)
         {
             var query = _userRepository.GetAll().WhereIf(
                    !string.IsNullOrWhiteSpace(input.Filter),
                   e=> e.Name.ToString().Contains(input.Filter)
                );

            var totalCount = await query.CountAsync();

            var userList = await query
                .PageBy(input)
                .ToListAsync();

			var lookupTableDtoList = new List<UserLookupTableDto>();
			foreach(var user in userList){
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
         }		 [AbpAuthorize(AppPermissions.Pages_Temples)]
         public async Task<PagedResultDto<CityLookupTableDto>> GetAllCityForLookupTable(GetAllForLookupTableInput input)
         {
             var query = _cityRepository.GetAll().WhereIf(
                    !string.IsNullOrWhiteSpace(input.Filter),
                   e=> e.cid.ToString().Contains(input.Filter)
                );

            var totalCount = await query.CountAsync();

            var cityList = await query
                .PageBy(input)
                .ToListAsync();

			var lookupTableDtoList = new List<CityLookupTableDto>();
			foreach(var city in cityList){
				lookupTableDtoList.Add(new CityLookupTableDto
				{
					Id = city.Id,
					DisplayName = city.cid.ToString()
				});
			}

            return new PagedResultDto<CityLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
         }

        public Task JoinIn(EntityDto input)
        {
            throw new NotImplementedException();
        }

        public Task ApproveJoinInMember(ApproveJoinInMemberInput approveJoinIn)
        {
            throw new NotImplementedException();
        }

        public Task LeaveTemple(EntityDto input)
        {
            throw new NotImplementedException();
        }

        public Task ChangeTempleMasterRole(ChangeTempleMasterRoleInput changeTemple)
        {
            throw new NotImplementedException();
        }
    }
}