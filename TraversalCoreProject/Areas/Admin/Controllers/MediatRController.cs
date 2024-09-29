using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    public class MediatRController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
