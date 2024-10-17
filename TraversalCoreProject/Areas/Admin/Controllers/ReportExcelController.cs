using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class ReportExcelController : Controller
    {
        TraversalContext context = new TraversalContext();
        private readonly IExcelService _excelService;

        public ReportExcelController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("DestinationList")]
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
        [Route("StaticExcelReport")]
        public IActionResult StaticExcelReport()
        {
            return File(_excelService.ExcelList(DestinationList()), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "YeniExcel.xlsx");         
        }
        [Route("DestinationExcelReport")]
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
