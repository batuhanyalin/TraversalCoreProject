using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Win32;
using TraversalCoreProject.BusinessLayer.ValidationRules;
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
		public IActionResult GuideApplicationCheck()
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
			var validation = new LoginValidator().Validate(loginDto);
			if (!validation.IsValid)
			{
				foreach (var error in validation.Errors)
				{
					ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
				}
				return View(loginDto);
			}
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
				if (result.Succeeded)
				{
					var user = await _userManager.FindByNameAsync(loginDto.UserName);
					var userRole = await _userManager.GetRolesAsync(user);
					if (userRole.FirstOrDefault() == "Admin")
					{
						return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
					}
					if (userRole.FirstOrDefault() == "Member")
					{
						return RedirectToAction("Index", "Dashboard", new { area = "Member" });
					}
                    if (userRole.FirstOrDefault() == "Guide")
                    {
                        return RedirectToAction("Index", "Dashboard", new { area = "Member" });
                    }
                    if (userRole.FirstOrDefault() == "GuideApplication")
					{
						await _signInManager.SignOutAsync();
						return RedirectToAction("GuideApplicationCheck", "Login");
					}

				}
				else
				{
						ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
				}
			}
			return View();
		}
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index");
		}
	}
}
