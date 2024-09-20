using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ContactController : Controller
    {
        public IActionResult ListContact()
        {
            return View();
        }
    }
}
