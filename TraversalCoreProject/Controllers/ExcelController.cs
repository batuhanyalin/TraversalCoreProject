using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class ExcelController : Controller
    {
        TraversalContext context = new TraversalContext();

        public IActionResult Index()
        {
            return View();
        }

        public List<DestinationReportModel> DestinationList()
        {
            List<DestinationReportModel> destinationReportModels = new List<DestinationReportModel>();
            destinationReportModels = context.Destinations.Select(x => new DestinationReportModel
            {
                City = x.City,
                DayNight = x.DayNight,
                Price = x.Price,
                Country = x.Country,
                Capacity = x.Capacity,
            }).ToList();
            return destinationReportModels;
        }

        public IActionResult StaticExcelReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells[1, 1].Value = "Rota";
            workSheet.Cells[1, 2].Value = "Rehber";
            workSheet.Cells[1, 3].Value = "Kontenjan";

            workSheet.Cells[2, 1].Value = "Slovenya Jülyen Dağları";
            workSheet.Cells[2, 2].Value = "Emrah Safa Gürkan";
            workSheet.Cells[2, 3].Value = "18";

            workSheet.Cells[3, 1].Value = "Tayland Bangkok Turu";
            workSheet.Cells[3, 2].Value = "İlber ORTAYLI";
            workSheet.Cells[3, 3].Value = "50";

            workSheet.Cells[4, 1].Value = "Yunanistan Yunan Adaları";
            workSheet.Cells[4, 2].Value = "Fatih ALTAYLI";
            workSheet.Cells[4, 3].Value = "38";

            var bytes = excel.GetAsByteArray();

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "dosya1.xlsx");
        }

        public IActionResult DestinationExcelReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var workSheet = workbook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Ülke";
                workSheet.Cell(1, 2).Value = "Şehir";
                workSheet.Cell(1, 3).Value = "Konaklama Süresi";
                workSheet.Cell(1, 4).Value = "Kapasite";
                workSheet.Cell(1, 5).Value = "Fiyat";
                int rowCount = 2;
                foreach (var item in DestinationList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.Country;
                    workSheet.Cell(rowCount, 2).Value = item.City;
                    workSheet.Cell(rowCount, 3).Value = item.DayNight;
                    workSheet.Cell(rowCount, 4).Value = item.Capacity;
                    workSheet.Cell(rowCount, 5).Value = item.Price;
                    rowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "yeniListe.xlsx");
                }
            }
        }
    }
}
