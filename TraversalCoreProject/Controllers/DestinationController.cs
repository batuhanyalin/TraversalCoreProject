using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class DestinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DestinationDetail(int id)
        {
            return View();
        }
    }
}
