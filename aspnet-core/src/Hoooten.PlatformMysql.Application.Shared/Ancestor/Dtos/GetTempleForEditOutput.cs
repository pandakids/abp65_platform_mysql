using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetTempleForEditOutput
    {
		public CreateOrEditTempleDto Temple { get; set; }

		public string BinaryObjectBytes { get; set;}

		public string UserName { get; set;}

		public string Citycid { get; set;}


    }
}