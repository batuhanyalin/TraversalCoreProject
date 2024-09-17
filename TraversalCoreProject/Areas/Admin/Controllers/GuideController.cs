using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{

    public class GuideController : Controller
    {
        public IActionResult ListGuide()
        {
            return View();
        }
    }
}
