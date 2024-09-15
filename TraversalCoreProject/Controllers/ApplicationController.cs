using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
