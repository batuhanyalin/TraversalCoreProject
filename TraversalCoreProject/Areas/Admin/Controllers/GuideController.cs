using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class GuideController : Controller
    {
        public IActionResult ListGuide()
        {
            return View();
        }
    }
}
