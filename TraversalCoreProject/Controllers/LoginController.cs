using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.DtoLayer.LoginDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult ApprovedCheck()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            var userRole = await _userManager.GetRolesAsync(user);
            if (result.Succeeded)
            {
                if (userRole.FirstOrDefault() == "Admin")
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
                if (userRole.FirstOrDefault() =="Member")
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Member" });
                }
                else
                {
					return RedirectToAction("Index", "Default");
				}
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı adı veya parola yanlış");
            }
          return View();
        }
    }
}
