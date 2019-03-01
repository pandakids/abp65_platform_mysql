using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Hoooten.PlatformMysql.DataExporting.Excel.EpPlus;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;
using Hoooten.PlatformMysql.Storage;

namespace Hoooten.PlatformMysql.Ancestor.Exporting
{
    public class ForeActivitiesExcelExporter : EpPlusExcelExporterBase, IForeActivitiesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public ForeActivitiesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager)
            : base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetForeActivityForView> foreActivities)
        {
            return CreateExcelPackage(
                "ForeActivities.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add(L("ForeActivities"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Address"),
                        L("Content"),
                        (L("BinaryObject")) + L("TenantId"),
                        (L("Temple")) + L("Name")
                        );

                    AddObjects(
                        sheet, 2, foreActivities,
                        _ => _.ForeActivity.Name,
                        _ => _.ForeActivity.Address,
                        _ => _.ForeActivity.Content,
                        _ => _.BinaryObjectTenantId,
                        _ => _.TempleName
                        );

					

                });
        }
    }
}
