using ArGeTesvikTool.Business.Abstract;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.Report;
using ClosedXML.Excel;
using System.Collections.Generic;
using System.IO;

namespace ArGeTesvikTool.Business.Concrete.Report
{
    public class ExportExcelManager : IExportExcelService
    {
        public byte[] ActivityExportExcel(List<RdCenterCalPersonnelEntryDto> list, string excelName)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(excelName);

            worksheet.Columns().Width = 25;

            var currentRow = 1;

            #region Header
            worksheet.Cell(currentRow, 1).Value = "Personel Adı Soyadı";
            worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 2).Value = "Sicil Numarası";
            worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 2).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 3).Value = "Çalışma Şekli";
            worksheet.Cell(currentRow, 3).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 3).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 4).Value = "Proje Kodu";
            worksheet.Cell(currentRow, 4).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 4).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 5).Value = "Proje Tanım";
            worksheet.Cell(currentRow, 5).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 5).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 6).Value = "Dışarıda Geçirilen Süre Kodu";
            worksheet.Cell(currentRow, 6).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 6).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 7).Value = "Dışarıda Geçirilen Süre Tanım";
            worksheet.Cell(currentRow, 7).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 7).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 8).Value = "Başlangıç Tarihi";
            worksheet.Cell(currentRow, 8).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 8).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 9).Value = "Bitiş Tarihi";
            worksheet.Cell(currentRow, 9).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 9).Style.Fill.BackgroundColor = XLColor.Gainsboro;
            #endregion

            #region Body
            foreach (var item in list)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = item.PersonnelFullName;
                worksheet.Cell(currentRow, 2).Value = item.RegistrationNo;
                worksheet.Cell(currentRow, 3).Value = item.WorkType;
                worksheet.Cell(currentRow, 4).Value = item.ProjectCode;
                worksheet.Cell(currentRow, 5).Value = item.ProjectName;
                worksheet.Cell(currentRow, 6).Value = item.TimeAwayCode;
                worksheet.Cell(currentRow, 7).Value = item.TimeAwayName;
                worksheet.Cell(currentRow, 8).Value = item.StartDate;
                worksheet.Cell(currentRow, 9).Value = item.EndDate;
            }
            #endregion

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream.ToArray();
        }

        public byte[] PdksExportExcel(List<RdCenterCalPersAttendanceDto> list, string excelName)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(excelName);

            worksheet.Columns().Width = 25;

            var currentRow = 1;

            #region Header
            worksheet.Cell(currentRow, 1).Value = "Personel Adı";
            worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 2).Value = "Personel Soyadı";
            worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 2).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 3).Value = "Turnike Adı";
            worksheet.Cell(currentRow, 3).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 3).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 4).Value = "Tarih/Saat";
            worksheet.Cell(currentRow, 4).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 4).Style.Fill.BackgroundColor = XLColor.Gainsboro;
            #endregion

            #region Body
            foreach (var item in list)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = item.Name;
                worksheet.Cell(currentRow, 2).Value = item.Surname;
                worksheet.Cell(currentRow, 3).Value = item.TerminalName;
                worksheet.Cell(currentRow, 4).Value = item.EventTime;
            }
            #endregion

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream.ToArray();
        }

        public byte[] IncomeExportExcel(List<IncomeDto> list, string excelName)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(excelName);

            worksheet.Columns().Width = 75;

            var currentRow = 1;

            #region Header
            worksheet.Cell(currentRow, 1).Value = "Sicil No";
            worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 2).Value = "Personel Adı Soyadı";
            worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 2).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 3).Value = "Ar-Ge Merkezi İçerisinde Geçirilen Süre (SAAT)";
            worksheet.Cell(currentRow, 3).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 3).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 4).Value = "Uzaktan çalışma süresi";
            worksheet.Cell(currentRow, 4).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 4).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 5).Value = "Projeler veya Lisansüstü Eğitim Kapsamında Ar-Ge Merkezi Dışında Geçirilen Teşvikli Süre (SAAT)";
            worksheet.Cell(currentRow, 5).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 5).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 6).Value = "Ar-Ge Merkezi Dışında Geçirilen Diğer Teşviksiz R&D Zamanı (SAAT)";
            worksheet.Cell(currentRow, 6).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 6).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 7).Value = "Ar-Ge Merkezi Dışında Geçirilen Non R&D Zamanı (SAAT)";
            worksheet.Cell(currentRow, 7).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 7).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 8).Value = "Ar-Ge Merkezi Dışında Geçirilen Diğer Zamanlar (SAAT)";
            worksheet.Cell(currentRow, 8).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 8).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 9).Value = "Ücretli Yıllık İzinler (SAAT)";
            worksheet.Cell(currentRow, 9).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 9).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 10).Value = "Kullanılacak Esas Gün";
            worksheet.Cell(currentRow, 10).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 10).Style.Fill.BackgroundColor = XLColor.Gainsboro;
            #endregion

            #region Body
            foreach (var item in list)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = item.RegistrationNo;
                worksheet.Cell(currentRow, 2).Value = item.PersonnelFullName;
                worksheet.Cell(currentRow, 3).Value = item.RdCenterTimeSpend;
                worksheet.Cell(currentRow, 4).Value = item.RemoteTimeSpend;
                worksheet.Cell(currentRow, 5).Value = item.ProjectTimeSpend;
                worksheet.Cell(currentRow, 6).Value = item.UncentiveTimeSpend;
                worksheet.Cell(currentRow, 7).Value = item.NonRdCenterTimeSpend;
                worksheet.Cell(currentRow, 8).Value = item.NonRdCenterOtherTimeSpend;
                worksheet.Cell(currentRow, 9).Value = item.AnnualLeaveTimeSpend;
                worksheet.Cell(currentRow, 10).Value = item.BaseUsedDay;
            }
            #endregion

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream.ToArray();
        }

        public byte[] SsiExportExcel(List<SocialSecurityDto> list, string excelName)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(excelName);

            worksheet.Columns().Width = 75;

            var currentRow = 1;

            #region Header
            worksheet.Cell(currentRow, 1).Value = "Sicil No";
            worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 2).Value = "Personel Adı Soyadı";
            worksheet.Cell(currentRow, 2).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 2).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 3).Value = "T/Z-K/Z";
            worksheet.Cell(currentRow, 3).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 3).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 4).Value = "Hafta Numarası";
            worksheet.Cell(currentRow, 4).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 4).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 5).Value = "Önceki Ay Devir";
            worksheet.Cell(currentRow, 5).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 5).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 6).Value = "Teşvikli Çalışma Süresi";
            worksheet.Cell(currentRow, 6).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 6).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 7).Value = "Yıllık İzin Önceki Ay Devir";
            worksheet.Cell(currentRow, 7).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 7).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 8).Value = "Yıllık İzin Süresi";
            worksheet.Cell(currentRow, 8).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 8).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 9).Value = "Hafta Sonu Süresi";
            worksheet.Cell(currentRow, 9).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 9).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 10).Value = "Resmi Tatil Süresi";
            worksheet.Cell(currentRow, 10).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 10).Style.Fill.BackgroundColor = XLColor.Gainsboro;

            worksheet.Cell(currentRow, 11).Value = "SGK Arge Günü";
            worksheet.Cell(currentRow, 11).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 11).Style.Fill.BackgroundColor = XLColor.Gainsboro;
            #endregion

            #region Body
            foreach (var item in list)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = item.RegistrationNo;
                worksheet.Cell(currentRow, 2).Value = item.PersonnelFullName;
                worksheet.Cell(currentRow, 3).Value = item.WorkType;
                worksheet.Cell(currentRow, 4).Value = item.WeekNumber;
                worksheet.Cell(currentRow, 5).Value = item.PreMonthTransfer;
                worksheet.Cell(currentRow, 6).Value = item.IncentiveWorkingHour;
                worksheet.Cell(currentRow, 7).Value = item.PreMonthAnnuelLeaveHour;
                worksheet.Cell(currentRow, 8).Value = item.AnnuelLeaveWorkingHour;
                worksheet.Cell(currentRow, 9).Value = item.WeekendWorkingHour;
                worksheet.Cell(currentRow, 10).Value = item.PublicHolidayWorkingHour;
                worksheet.Cell(currentRow, 11).Value = item.SsiWorkingHour;
            }
            #endregion

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);

            return stream.ToArray();
        }
    }
}
