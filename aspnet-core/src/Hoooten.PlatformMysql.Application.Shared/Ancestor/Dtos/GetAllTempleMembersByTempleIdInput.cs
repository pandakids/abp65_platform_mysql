using Abp.Application.Services.Dto;
using System;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetAllTempleMembersByTempleIdInput : GetAllTempleMembersInput
    {

        /// <summary>
        /// ������������ȡ
        /// </summary>
		 public int TempleId { get; set; }
    }
}