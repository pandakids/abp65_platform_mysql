
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class CreateOrEditTempleDto : FullAuditedEntityDto<int?>
    {

		[Required]
		[StringLength(TempleConsts.MaxNameLength, MinimumLength = TempleConsts.MinNameLength)]
		public string Name { get; set; }
		
		
		[StringLength(TempleConsts.MaxCodeLength, MinimumLength = TempleConsts.MinCodeLength)]
		public string Code { get; set; }
		
		
		[Required]
		[StringLength(TempleConsts.MaxFanmilyNameLength, MinimumLength = TempleConsts.MinFanmilyNameLength)]
		public string FanmilyName { get; set; }
		
		
		[StringLength(TempleConsts.MaxAddressLength, MinimumLength = TempleConsts.MinAddressLength)]
		public string Address { get; set; }
		
		
		[StringLength(TempleConsts.MaxPhotoLength, MinimumLength = TempleConsts.MinPhotoLength)]
		public string Photo { get; set; }
		
		
		public double Lon { get; set; }
		
		
		public double Lat { get; set; }
		
		
		 public Guid? BinaryObjectId { get; set; }
		 
		 		 public long? UserId { get; set; }
		 
		 		 public int? CityId { get; set; }
		 
		 
    }
}