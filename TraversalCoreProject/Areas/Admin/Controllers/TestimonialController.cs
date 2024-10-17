using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult CreateTestimonial()
        {
            return View();
        }
    }
}
