using System.Collections.Generic;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;

namespace Hoooten.PlatformMysql.Ancestor.Exporting
{
    public interface IForeFathersExcelExporter
    {
        FileDto ExportToFile(List<GetForeFatherForView> foreFathers);
    }
}