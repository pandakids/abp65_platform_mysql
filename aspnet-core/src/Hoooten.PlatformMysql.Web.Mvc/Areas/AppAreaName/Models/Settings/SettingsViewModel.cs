﻿using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Configuration.Tenants.Dto;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Settings
{
    public class SettingsViewModel
    {
        public TenantSettingsEditDto Settings { get; set; }
        
        public List<ComboboxItemDto> TimezoneItems { get; set; }
    }
}