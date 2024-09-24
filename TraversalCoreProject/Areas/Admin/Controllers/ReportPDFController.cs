using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    public class ReportPDFController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
