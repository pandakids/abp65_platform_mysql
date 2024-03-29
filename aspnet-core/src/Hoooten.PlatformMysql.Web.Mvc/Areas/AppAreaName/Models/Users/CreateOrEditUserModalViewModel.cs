﻿using System.Collections.Generic;
using System.Linq;
using Abp.AutoMapper;
using Hoooten.PlatformMysql.Authorization.Users.Dto;
using Hoooten.PlatformMysql.Security;
using Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Common;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Users
{
    [AutoMapFrom(typeof(GetUserForEditOutput))]
    public class CreateOrEditUserModalViewModel : GetUserForEditOutput, IOrganizationUnitsEditViewModel
    {
        public bool CanChangeUserName
        {
            get { return User.UserName != Authorization.Users.User.AdminUserName; }
        }

        public int AssignedRoleCount
        {
            get { return Roles.Count(r => r.IsAssigned); }
        }

        public bool IsEditMode
        {
            get { return User.Id.HasValue; }
        }

        public PasswordComplexitySetting PasswordComplexitySetting { get; set; }

        public CreateOrEditUserModalViewModel(GetUserForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}