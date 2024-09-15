using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
