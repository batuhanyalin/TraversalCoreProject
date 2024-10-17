using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class IndexBannerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
