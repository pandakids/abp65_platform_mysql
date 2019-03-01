using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetTempleMemberForEditOutput
    {
		public CreateOrEditTempleMemberDto TempleMember { get; set; }

		public string UserName { get; set;}

		public string TempleName { get; set;}


    }
}