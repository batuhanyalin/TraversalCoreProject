using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
