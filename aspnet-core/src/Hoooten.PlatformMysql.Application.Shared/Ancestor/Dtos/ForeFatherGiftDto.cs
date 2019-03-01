
using System;
using Abp.Application.Services.Dto;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class ForeFatherGiftDto : EntityDto
    {
		public int TheGiftType { get; set; }

		public int GiftNumber { get; set; }


		 public int ForeFatherId { get; set; }

		 		 public long? UserId { get; set; }

		 
    }
}