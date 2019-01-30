using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Editions.Dto;

namespace Hoooten.PlatformMysql.Web.Areas.AppAreaName.Models.Common
{
    public interface IFeatureEditViewModel
    {
        List<NameValueDto> FeatureValues { get; set; }

        List<FlatFeatureDto> Features { get; set; }
    }
}