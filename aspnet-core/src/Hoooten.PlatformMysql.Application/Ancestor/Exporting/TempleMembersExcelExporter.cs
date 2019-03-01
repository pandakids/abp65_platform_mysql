using System.Collections.Generic;
using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Hoooten.PlatformMysql.DataExporting.Excel.EpPlus;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;
using Hoooten.PlatformMysql.Storage;

namespace Hoooten.PlatformMysql.Ancestor.Exporting
{
    public class TempleMembersExcelExporter : EpPlusExcelExporterBase, ITempleMembersExcelExporter
    {

        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public TempleMembersExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager)
            : base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<GetTempleMemberForView> templeMembers)
        {
            return CreateExcelPackage(
                "TempleMembers.xlsx",
                excelPackage =>
                {
                    var sheet = excelPackage.Workbook.Worksheets.Add(L("TempleMembers"));
                    sheet.OutLineApplyStyle = true;

                    AddHeader(
                        sheet,
                        L("Marks"),
                        L("IsApproved"),
                        (L("User")) + L("Name"),
                        (L("Temple")) + L("Name")
                        );

                    AddObjects(
                        sheet, 2, templeMembers,
                        _ => _.TempleMember.Marks,
                        _ => _.TempleMember.IsApproved,
                        _ => _.UserName,
                        _ => _.TempleName
                        );

					

                });
        }
    }
}
