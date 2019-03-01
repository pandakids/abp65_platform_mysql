using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetForeFatherForEditOutput
    {
		public CreateOrEditForeFatherDto ForeFather { get; set; }

		public string BinaryObjectTenantId { get; set;}


    }
}