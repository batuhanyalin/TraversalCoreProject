using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
