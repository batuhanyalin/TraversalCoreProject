using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
