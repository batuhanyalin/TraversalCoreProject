using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult SendMail()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SendMail(MailRequest mailRequest)
        {
            return View();
        }
    }
}
