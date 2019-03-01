
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class CreateOrEditUserGiftDto : FullAuditedEntityDto<int?>
    {

		public int TheGiftType { get; set; }
		
		
		public int GiftNumber { get; set; }
		
		
		public DateTime? SignDate { get; set; }
		
		
		public int GiftSource { get; set; }
		
		
		 public long UserId { get; set; }
		 
		 
    }
}