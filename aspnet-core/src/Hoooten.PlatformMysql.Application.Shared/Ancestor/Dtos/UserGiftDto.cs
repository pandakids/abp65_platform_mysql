
using System;
using Abp.Application.Services.Dto;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class UserGiftDto : EntityDto
    {
		public int TheGiftType { get; set; }

		public int GiftNumber { get; set; }

		public DateTime? SignDate { get; set; }

		public int GiftSource { get; set; }


		 public long UserId { get; set; }

		 
    }
}