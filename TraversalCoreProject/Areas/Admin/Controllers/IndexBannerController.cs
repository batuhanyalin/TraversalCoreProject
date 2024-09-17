using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    public class IndexBannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
