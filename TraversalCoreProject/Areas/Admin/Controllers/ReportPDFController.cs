using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [AllowAnonymous]
    public class ReportPDFController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Route("StaticPDFReport")]
        public IActionResult StaticPDFReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Rezervasyon PDF Raporu");
            document.Add(paragraph);
            document.Close();

            return File("/PDFReports/dosya1.pdf","application/pdf","dosya1.pdf");
        }
        [Route("StaticCustomerReport")]
        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PDFReports/" + "dosya2.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);
            pdfPTable.AddCell("Misafir Adı");
            pdfPTable.AddCell("Misafir Soyadı");
            pdfPTable.AddCell("Misafir TC");

            pdfPTable.AddCell("Naim");
            pdfPTable.AddCell("SÜLEYMANOĞLU");
            pdfPTable.AddCell("11111111111");

            pdfPTable.AddCell("Rıza");
            pdfPTable.AddCell("KAYAALP");
            pdfPTable.AddCell("123456789101");

            pdfPTable.AddCell("Muhammed");
            pdfPTable.AddCell("ALİ");
            pdfPTable.AddCell("22222222222");
            document.Add(pdfPTable);
            document.Close();

            return File("/PDFReports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }
    }
}
