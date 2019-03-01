using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetUserGiftForEditOutput
    {
		public CreateOrEditUserGiftDto UserGift { get; set; }

		public string UserName { get; set;}


    }
}