using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.Report;
using System.Collections.Generic;

namespace ArGeTesvikTool.Business.Abstract
{
    public interface IExportExcelService
    {
        byte[] ActivityExportExcel(List<RdCenterCalPersonnelEntryDto> list, string excelName);
        byte[] PdksExportExcel(List<RdCenterCalPersAttendanceDto> list, string excelName);
        byte[] IncomeExportExcel(List<IncomeDto> list, string excelName);
        byte[] SsiExportExcel(List<SocialSecurityDto> list, string excelName);
    }
}
