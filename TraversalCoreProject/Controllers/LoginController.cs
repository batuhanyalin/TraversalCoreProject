using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
