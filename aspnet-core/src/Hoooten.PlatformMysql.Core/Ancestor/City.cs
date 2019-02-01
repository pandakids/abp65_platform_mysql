

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Entities;

namespace Hoooten.PlatformMysql.Ancestor
{
	[Table("Cities")]
    public class City : Entity 
    {



		[Required]
		[StringLength(CityConsts.MaxcidLength, MinimumLength = CityConsts.MincidLength)]
		public virtual string cid { get; set; }
		
		[Required]
		[StringLength(CityConsts.MaxlocationLength, MinimumLength = CityConsts.MinlocationLength)]
		public virtual string location { get; set; }
		
		[Required]
		[StringLength(CityConsts.Maxparent_cityLength, MinimumLength = CityConsts.Minparent_cityLength)]
		public virtual string parent_city { get; set; }
		
		[Required]
		[StringLength(CityConsts.Maxadmin_areaLength, MinimumLength = CityConsts.Minadmin_areaLength)]
		public virtual string admin_area { get; set; }
		
		[Required]
		[StringLength(CityConsts.MaxcntyLength, MinimumLength = CityConsts.MincntyLength)]
		public virtual string cnty { get; set; }
		
		[Required]
		[StringLength(CityConsts.MaxlatLength, MinimumLength = CityConsts.MinlatLength)]
		public virtual string lat { get; set; }
		
		[Required]
		[StringLength(CityConsts.MaxlonLength, MinimumLength = CityConsts.MinlonLength)]
		public virtual string lon { get; set; }
		
		[StringLength(CityConsts.MaxtzLength, MinimumLength = CityConsts.MintzLength)]
		public virtual string tz { get; set; }
		
		[Required]
		[StringLength(CityConsts.MaxtypeLength, MinimumLength = CityConsts.MintypeLength)]
		public virtual string type { get; set; }
		

    }
}