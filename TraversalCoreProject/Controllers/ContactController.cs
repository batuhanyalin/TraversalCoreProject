using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
