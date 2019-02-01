using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetCityForEditOutput
    {
		public CreateOrEditCityDto City { get; set; }


    }
}