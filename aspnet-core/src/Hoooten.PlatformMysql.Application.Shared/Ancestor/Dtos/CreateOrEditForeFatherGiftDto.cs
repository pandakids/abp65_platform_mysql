
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class CreateOrEditForeFatherGiftDto : FullAuditedEntityDto<int?>
    {

		public int TheGiftType { get; set; }
		
		
		public int GiftNumber { get; set; }
		
		
		 public int ForeFatherId { get; set; }
		 
		 		 public long? UserId { get; set; }
		 
		 
    }
}