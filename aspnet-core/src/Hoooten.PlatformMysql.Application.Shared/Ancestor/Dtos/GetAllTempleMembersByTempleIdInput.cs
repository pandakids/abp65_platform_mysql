using Abp.Application.Services.Dto;
using System;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class GetAllTempleMembersByTempleIdInput : GetAllTempleMembersInput
    {

        /// <summary>
        /// 根据宗堂来获取
        /// </summary>
		 public int TempleId { get; set; }
    }
}