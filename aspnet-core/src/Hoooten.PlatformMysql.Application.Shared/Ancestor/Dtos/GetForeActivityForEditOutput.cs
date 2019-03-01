using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetForeActivityForEditOutput
    {
		public CreateOrEditForeActivityDto ForeActivity { get; set; }

		public string BinaryObjectTenantId { get; set;}

		public string TempleName { get; set;}


    }
}