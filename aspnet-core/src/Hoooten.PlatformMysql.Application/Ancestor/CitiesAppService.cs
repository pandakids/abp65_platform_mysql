
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
	[AbpAuthorize(AppPermissions.Pages_Cities)]
    public class CitiesAppService : PlatformMysqlAppServiceBase, ICitiesAppService
    {
		 private readonly IRepository<City> _cityRepository;
		 private readonly ICitiesExcelExporter _citiesExcelExporter;
		 

		  public CitiesAppService(IRepository<City> cityRepository, ICitiesExcelExporter citiesExcelExporter ) 
		  {
			_cityRepository = cityRepository;
			_citiesExcelExporter = citiesExcelExporter;
			
		  }

		 public async Task<PagedResultDto<GetCityForView>> GetAll(GetAllCitiesInput input)
         {

			var filteredCities = _cityRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.cid.Contains(input.Filter) || e.location.Contains(input.Filter) || e.parent_city.Contains(input.Filter) || e.admin_area.Contains(input.Filter) || e.cnty.Contains(input.Filter) || e.lat.Contains(input.Filter) || e.lon.Contains(input.Filter) || e.tz.Contains(input.Filter) || e.type.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.cidFilter),  e => e.cid.ToLower() == input.cidFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.locationFilter),  e => e.location.ToLower() == input.locationFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.parent_cityFilter),  e => e.parent_city.ToLower() == input.parent_cityFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.admin_areaFilter),  e => e.admin_area.ToLower() == input.admin_areaFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.cntyFilter),  e => e.cnty.ToLower() == input.cntyFilter.ToLower().Trim());


			var query = (from o in filteredCities
                         
                         select new GetCityForView() { City = ObjectMapper.Map<CityDto>(o)
						 
						 })
						 ;

            var totalCount = await query.CountAsync();

            var cities = await query
                .OrderBy(input.Sorting ?? "city.id asc")
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetCityForView>(
                totalCount,
                cities
            );
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_Cities_Edit)]
		 public async Task<GetCityForEditOutput> GetCityForEdit(EntityDto input)
         {
            var city = await _cityRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetCityForEditOutput {City = ObjectMapper.Map<CreateOrEditCityDto>(city)};

			
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditCityDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_Cities_Create)]
		 private async Task Create(CreateOrEditCityDto input)
         {
            var city = ObjectMapper.Map<City>(input);

			

            await _cityRepository.InsertAsync(city);
         }

		 [AbpAuthorize(AppPermissions.Pages_Cities_Edit)]
		 private async Task Update(CreateOrEditCityDto input)
         {
            var city = await _cityRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, city);
         }

		 [AbpAuthorize(AppPermissions.Pages_Cities_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _cityRepository.DeleteAsync(input.Id);
         }

		 public async Task<FileDto> GetCitiesToExcel(GetAllCitiesForExcelInput input)
         {

			var filteredCities = _cityRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false  || e.cid.Contains(input.Filter) || e.location.Contains(input.Filter) || e.parent_city.Contains(input.Filter) || e.admin_area.Contains(input.Filter) || e.cnty.Contains(input.Filter) || e.lat.Contains(input.Filter) || e.lon.Contains(input.Filter) || e.tz.Contains(input.Filter) || e.type.Contains(input.Filter))
						.WhereIf(!string.IsNullOrWhiteSpace(input.cidFilter),  e => e.cid.ToLower() == input.cidFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.locationFilter),  e => e.location.ToLower() == input.locationFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.parent_cityFilter),  e => e.parent_city.ToLower() == input.parent_cityFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.admin_areaFilter),  e => e.admin_area.ToLower() == input.admin_areaFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.cntyFilter),  e => e.cnty.ToLower() == input.cntyFilter.ToLower().Trim());


			var query = (from o in filteredCities
                         
                         select new GetCityForView() { City = ObjectMapper.Map<CityDto>(o)
						 
						 })
						 ;


            var CityListDtos = await query.ToListAsync();

            return _citiesExcelExporter.ExportToFile(CityListDtos);
         }


    }
}