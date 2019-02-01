using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Hoooten.PlatformMysql.DataExporting.Excel.EpPlus;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;
using Hoooten.PlatformMysql.Storage;

namespace Hoooten.PlatformMysql.Ancestor.Exporting
{
    public class CitiesExcelExporter : EpPlusExcelExporterBase, ICitiesExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public CitiesExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager)
            : base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetCityForView> cities)
        {
            return CreateExcelPackage(
                "Cities.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add(L("Cities"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        L("cid"),
                        L("location"),
                        L("parent_city"),
                        L("admin_area"),
                        L("cnty"),
                        L("lat"),
                        L("lon"),
                        L("tz"),
                        L("type")
                        );

                    AddObjects(
                        sheet, 2, cities,
                        _ => _.City.cid,
                        _ => _.City.location,
                        _ => _.City.parent_city,
                        _ => _.City.admin_area,
                        _ => _.City.cnty,
                        _ => _.City.lat,
                        _ => _.City.lon,
                        _ => _.City.tz,
                        _ => _.City.type
                        );

					

                });
        }
    }
}
