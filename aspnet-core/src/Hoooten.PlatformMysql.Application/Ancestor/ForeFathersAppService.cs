using Hoooten.PlatformMysql.Storage;

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
	[AbpAuthorize(AppPermissions.Pages_ForeFathers)]
    public class ForeFathersAppService : PlatformMysqlAppServiceBase, IForeFathersAppService
    {
		 private readonly IRepository<ForeFather> _foreFatherRepository;
		 private readonly IForeFathersExcelExporter _foreFathersExcelExporter;
		 private readonly IRepository<BinaryObject,Guid> _binaryObjectRepository;
		 

		  public ForeFathersAppService(IRepository<ForeFather> foreFatherRepository, IForeFathersExcelExporter foreFathersExcelExporter , IRepository<BinaryObject, Guid> binaryObjectRepository) 
		  {
			_foreFatherRepository = foreFatherRepository;
			_foreFathersExcelExporter = foreFathersExcelExporter;
			_binaryObjectRepository = binaryObjectRepository;
		
		  }

		 public async Task<PagedResultDto<GetForeFatherForView>> GetAll(GetAllForeFathersInput input)
         {

			var filteredForeFathers = _foreFatherRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.Name.Contains(input.Filter) || e.Century.Contains(input.Filter) || e.Marks.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.NameFilter),  e => e.Name.ToLower() == input.NameFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.CenturyFilter),  e => e.Century.ToLower() == input.CenturyFilter.ToLower().Trim());


			var query = (from o in filteredForeFathers
                         join o1 in _binaryObjectRepository.GetAll() on o.BinaryObjectId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         
                         select new GetForeFatherForView() { ForeFather = ObjectMapper.Map<ForeFatherDto>(o)
						 , BinaryObjectTenantId = s1 == null ? "" : s1.TenantId.ToString()
					
						 })
						 
						.WhereIf(!string.IsNullOrWhiteSpace(input.BinaryObjectTenantIdFilter), e => e.BinaryObjectTenantId.ToLower() == input.BinaryObjectTenantIdFilter.ToLower().Trim());

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
            var foreFather = ObjectMapper.Map<ForeFather>(input);

			

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
                         
                         select new GetForeFatherForView() { ForeFather = ObjectMapper.Map<ForeFatherDto>(o)
						 , BinaryObjectTenantId = s1 == null ? "" : s1.TenantId.ToString()
					
						 })
						 
						.WhereIf(!string.IsNullOrWhiteSpace(input.BinaryObjectTenantIdFilter), e => e.BinaryObjectTenantId.ToLower() == input.BinaryObjectTenantIdFilter.ToLower().Trim());


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
         }

        public Task ReSetPosition(ReSetPositionInput input)
        {
            throw new NotImplementedException();
        }
    }
}