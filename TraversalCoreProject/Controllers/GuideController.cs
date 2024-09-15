using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class GuideController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GuideDetail(int id)
        {
            return View();
        }
    }
}
