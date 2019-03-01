
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class CreateOrEditTempleMemberDto : FullAuditedEntityDto<int?>
    {

		[StringLength(TempleMemberConsts.MaxMarksLength, MinimumLength = TempleMemberConsts.MinMarksLength)]
		public string Marks { get; set; }
		
		
		public bool IsApproved { get; set; }
		
		
		 public long UserId { get; set; }
		 
		 		 public int TempleId { get; set; }
		 
		 
    }
}