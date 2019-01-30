using Abp.AutoMapper;
using Hoooten.PlatformMysql.Authorization.Roles.Dto;
using Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Common;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class CreateOrEditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public bool IsEditMode
        {
            get { return Role.Id.HasValue; }
        }

        public CreateOrEditRoleModalViewModel(GetRoleForEditOutput output)
        {
            output.MapTo(this);
        }
    }
}