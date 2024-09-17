using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    public class DestinationController : Controller
    {
        public IActionResult ListDestination()
        {
            return View();
        }
    }
}
