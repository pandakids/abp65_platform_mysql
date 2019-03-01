using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetForeFatherGiftForEditOutput
    {
		public CreateOrEditForeFatherGiftDto ForeFatherGift { get; set; }

		public string ForeFatherName { get; set;}

		public string UserName { get; set;}


    }
}