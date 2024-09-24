using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    public class ExcelController : Controller
    {
        TraversalContext context = new TraversalContext();
        public IActionResult Index()
        {
            ExcelPackage excel=new ExcelPackage();
            var workSheet=excel.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells[1,1].Value="Rota";
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

            var bytes= excel.GetAsByteArray();

            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","dosya1.xlsx");
        }
        public List<DestinationReportModel> DestinationList()
        {
            List<DestinationReportModel> destinationReportModels = new List<DestinationReportModel>();
          destinationReportModels=context.Destinations.Select(x=>new DestinationReportModel
          {
              City = x.City,
              DayNight = x.DayNight,
              Price = x.Price,
              Country = x.Country,
              Capacity = x.Capacity,
          }).ToList();
            return destinationReportModels;
        }
        public IActionResult DestinationExcelReport()
        {
            using(var workbook= new XLWorkbook)
        }
    }
}
