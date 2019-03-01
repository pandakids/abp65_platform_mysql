
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class CreateOrEditForeActivityDto : FullAuditedEntityDto<int?>
    {

		[Required]
		[StringLength(ForeActivityConsts.MaxNameLength, MinimumLength = ForeActivityConsts.MinNameLength)]
		public string Name { get; set; }
		
		
		[StringLength(ForeActivityConsts.MaxAddressLength, MinimumLength = ForeActivityConsts.MinAddressLength)]
		public string Address { get; set; }
		
		
		[StringLength(ForeActivityConsts.MaxContentLength, MinimumLength = ForeActivityConsts.MinContentLength)]
		public string Content { get; set; }
		
		
		 public Guid? BinaryObjectId { get; set; }
		 
		 		 public int? TempleId { get; set; }
		 
		 
    }
}