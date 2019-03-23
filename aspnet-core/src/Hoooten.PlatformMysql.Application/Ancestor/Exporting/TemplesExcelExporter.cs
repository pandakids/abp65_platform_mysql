using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Hoooten.PlatformMysql.DataExporting.Excel.EpPlus;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;
using Hoooten.PlatformMysql.Storage;

namespace Hoooten.PlatformMysql.Ancestor.Exporting
{
    public class TemplesExcelExporter : EpPlusExcelExporterBase, ITemplesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public TemplesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager)
            : base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetTempleForView> temples)
        {
            return CreateExcelPackage(
                "Temples.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add(L("Temples"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Code"),
                        L("FamilyName"),
                        L("Address"),
                        L("Photo"),
                        L("IsShow"),
                        L("Lon"),
                        L("Lat"),
                        (L("BinaryObject")) + L("Bytes"),
                        (L("User")) + L("Name"),
                        (L("City")) + L("cid")
                        );

                    AddObjects(
                        sheet, 2, temples,
                        _ => _.Temple.Name,
                        _ => _.Temple.Code,
                        _ => _.Temple.FanmilyName,
                        _ => _.Temple.Address,
                        _ => _.Temple.Photo,
                        _ => _.Temple.IsShow,
                        _ => _.Temple.Lon,
                        _ => _.Temple.Lat,
                        _ => _.BinaryObjectBytes,
                        _ => _.UserName,
                        _ => _.Citycid
                        );

					

                });
        }
    }
}
