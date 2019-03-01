using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Hoooten.PlatformMysql.DataExporting.Excel.EpPlus;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;
using Hoooten.PlatformMysql.Storage;

namespace Hoooten.PlatformMysql.Ancestor.Exporting
{
    public class ForeFathersExcelExporter : EpPlusExcelExporterBase, IForeFathersExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public ForeFathersExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager)
            : base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetForeFatherForView> foreFathers)
        {
            return CreateExcelPackage(
                "ForeFathers.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add(L("ForeFathers"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        L("Name"),
                        L("Century"),
                        L("BornAt"),
                        L("DieAt"),
                        L("LoveNumber"),
                        L("FlowersNumber"),
                        L("MoneyNumber"),
                        L("GoldNumber"),
                        L("Lon"),
                        L("Lat"),
                        L("Marks"),
                        (L("BinaryObject")) + L("TenantId")
                        );

                    AddObjects(
                        sheet, 2, foreFathers,
                        _ => _.ForeFather.Name,
                        _ => _.ForeFather.Century,
                        _ => _timeZoneConverter.Convert(_.ForeFather.BornAt, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _timeZoneConverter.Convert(_.ForeFather.DieAt, _abpSession.TenantId, _abpSession.GetUserId()),
                        _ => _.ForeFather.LoveNumber,
                        _ => _.ForeFather.FlowersNumber,
                        _ => _.ForeFather.MoneyNumber,
                        _ => _.ForeFather.GoldNumber,
                        _ => _.ForeFather.Lon,
                        _ => _.ForeFather.Lat,
                        _ => _.ForeFather.Marks,
                        _ => _.BinaryObjectTenantId
                        );

					var bornAtColumn = sheet.Column(3);
                    bornAtColumn.Style.Numberformat.Format = "yyyy-mm-dd";
					bornAtColumn.AutoFit();
					var dieAtColumn = sheet.Column(4);
                    dieAtColumn.Style.Numberformat.Format = "yyyy-mm-dd";
					dieAtColumn.AutoFit();
					

                });
        }
    }
}
