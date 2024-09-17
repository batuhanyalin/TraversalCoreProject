using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult ListContact()
        {
            return View();
        }
    }
}
