using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.DtoLayer.LoginDtos;

namespace TraversalCoreProject.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(LoginDto loginDto)
        {
            return View();
        }
    }
}
