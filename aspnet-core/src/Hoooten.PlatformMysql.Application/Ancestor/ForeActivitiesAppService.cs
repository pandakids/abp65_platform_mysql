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

namespace Hoooten.PlatformMysql.Ancestor
{
	[AbpAuthorize(AppPermissions.Pages_ForeActivities)]
    public class ForeActivitiesAppService : PlatformMysqlAppServiceBase, IForeActivitiesAppService
    {
		 private readonly IRepository<ForeActivity> _foreActivityRepository;
		 private readonly IForeActivitiesExcelExporter _foreActivitiesExcelExporter;
		 private readonly IRepository<BinaryObject,Guid> _binaryObjectRepository;
		 private readonly IRepository<Temple,int> _templeRepository;
		 

		  public ForeActivitiesAppService(IRepository<ForeActivity> foreActivityRepository, IForeActivitiesExcelExporter foreActivitiesExcelExporter , IRepository<BinaryObject, Guid> binaryObjectRepository, IRepository<Temple, int> templeRepository) 
		  {
			_foreActivityRepository = foreActivityRepository;
			_foreActivitiesExcelExporter = foreActivitiesExcelExporter;
			_binaryObjectRepository = binaryObjectRepository;
		_templeRepository = templeRepository;
		
		  }

		 public async Task<PagedResultDto<GetForeActivityForView>> GetAll(GetAllForeActivitiesInput input)
         {

			var filteredForeActivities = _foreActivityRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter) || e.Address.Contains(input.Filter) || e.Content.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name.ToLower() == input.NameFilter.ToLower().Trim());


			var query = (from o in filteredForeActivities
                         join o1 in _binaryObjectRepository.GetAll() on o.BinaryObjectId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         join o2 in _templeRepository.GetAll() on o.TempleId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()
                         
                         select new GetForeActivityForView() { ForeActivity = ObjectMapper.Map<ForeActivityDto>(o)
						 , BinaryObjectTenantId = s1 == null ? "" : s1.TenantId.ToString()
					, TempleName = s2 == null ? "" : s2.Name.ToString()
					
						 })
						 
						.WhereIf(!string.IsNullOrWhiteSpace(input.BinaryObjectTenantIdFilter), e => e.BinaryObjectTenantId.ToLower() == input.BinaryObjectTenantIdFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.TempleNameFilter), e => e.TempleName.ToLower() == input.TempleNameFilter.ToLower().Trim());

            var totalCount = await query.CountAsync();

            var foreActivities = await query
                .OrderBy(input.Sorting ?? "foreActivity.id asc")
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetForeActivityForView>(
                totalCount,
                foreActivities
            );
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_ForeActivities_Edit)]
		 public async Task<GetForeActivityForEditOutput> GetForeActivityForEdit(EntityDto input)
         {
            var foreActivity = await _foreActivityRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetForeActivityForEditOutput {ForeActivity = ObjectMapper.Map<CreateOrEditForeActivityDto>(foreActivity)};

			if (output.ForeActivity.BinaryObjectId != null)
            {
                var binaryObject = await _binaryObjectRepository.FirstOrDefaultAsync((Guid)output.ForeActivity.BinaryObjectId);
                output.BinaryObjectTenantId = binaryObject.TenantId.ToString();
            }
			if (output.ForeActivity.TempleId != null)
            {
                var temple = await _templeRepository.FirstOrDefaultAsync((int)output.ForeActivity.TempleId);
                output.TempleName = temple.Name.ToString();
            }
			
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditForeActivityDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_ForeActivities_Create)]
		 private async Task Create(CreateOrEditForeActivityDto input)
         {
            var foreActivity = ObjectMapper.Map<ForeActivity>(input);

			

            await _foreActivityRepository.InsertAsync(foreActivity);
         }

		 [AbpAuthorize(AppPermissions.Pages_ForeActivities_Edit)]
		 private async Task Update(CreateOrEditForeActivityDto input)
         {
            var foreActivity = await _foreActivityRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, foreActivity);
         }

		 [AbpAuthorize(AppPermissions.Pages_ForeActivities_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _foreActivityRepository.DeleteAsync(input.Id);
         }

		 public async Task<FileDto> GetForeActivitiesToExcel(GetAllForeActivitiesForExcelInput input)
         {

			var filteredForeActivities = _foreActivityRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter) || e.Address.Contains(input.Filter) || e.Content.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name.ToLower() == input.NameFilter.ToLower().Trim());


			var query = (from o in filteredForeActivities
                         join o1 in _binaryObjectRepository.GetAll() on o.BinaryObjectId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         join o2 in _templeRepository.GetAll() on o.TempleId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()
                         
                         select new GetForeActivityForView() { ForeActivity = ObjectMapper.Map<ForeActivityDto>(o)
						 , BinaryObjectTenantId = s1 == null ? "" : s1.TenantId.ToString()
					, TempleName = s2 == null ? "" : s2.Name.ToString()
					
						 })
						 
						.WhereIf(!string.IsNullOrWhiteSpace(input.BinaryObjectTenantIdFilter), e => e.BinaryObjectTenantId.ToLower() == input.BinaryObjectTenantIdFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.TempleNameFilter), e => e.TempleName.ToLower() == input.TempleNameFilter.ToLower().Trim());


            var ForeActivityListDtos = await query.ToListAsync();

            return _foreActivitiesExcelExporter.ExportToFile(ForeActivityListDtos);
         }

		 [AbpAuthorize(AppPermissions.Pages_ForeActivities)]
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
         }		 [AbpAuthorize(AppPermissions.Pages_ForeActivities)]
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
    }
}