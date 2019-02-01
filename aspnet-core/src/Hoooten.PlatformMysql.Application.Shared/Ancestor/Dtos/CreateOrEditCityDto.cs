
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class CreateOrEditCityDto : EntityDto<int?>
    {

		[Required]
		[StringLength(CityConsts.MaxcidLength, MinimumLength = CityConsts.MincidLength)]
		public string cid { get; set; }
		
		
		[Required]
		[StringLength(CityConsts.MaxlocationLength, MinimumLength = CityConsts.MinlocationLength)]
		public string location { get; set; }
		
		
		[Required]
		[StringLength(CityConsts.Maxparent_cityLength, MinimumLength = CityConsts.Minparent_cityLength)]
		public string parent_city { get; set; }
		
		
		[Required]
		[StringLength(CityConsts.Maxadmin_areaLength, MinimumLength = CityConsts.Minadmin_areaLength)]
		public string admin_area { get; set; }
		
		
		[Required]
		[StringLength(CityConsts.MaxcntyLength, MinimumLength = CityConsts.MincntyLength)]
		public string cnty { get; set; }
		
		
		[Required]
		[StringLength(CityConsts.MaxlatLength, MinimumLength = CityConsts.MinlatLength)]
		public string lat { get; set; }
		
		
		[Required]
		[StringLength(CityConsts.MaxlonLength, MinimumLength = CityConsts.MinlonLength)]
		public string lon { get; set; }
		
		
		[StringLength(CityConsts.MaxtzLength, MinimumLength = CityConsts.MintzLength)]
		public string tz { get; set; }
		
		
		[Required]
		[StringLength(CityConsts.MaxtypeLength, MinimumLength = CityConsts.MintypeLength)]
		public string type { get; set; }
		
		

    }
}