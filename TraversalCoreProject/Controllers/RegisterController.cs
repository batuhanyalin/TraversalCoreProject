using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.DtoLayer.RegisterDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        private readonly IMapper _mapper;

        public RegisterController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
				registerDto.UserName = (registerDto.Name + registerDto.Surname).ToLower();
				var value = _mapper.Map<AppUser>(registerDto);
                value.IsActive = false;
                if (value.ImageUrl == null)
                {
                    value.ImageUrl = $"/images/users/no-image-users.jpg";
                }

                var register = await _userManager.CreateAsync(value, registerDto.Password);
                if (register.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(registerDto.UserName);
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, currentRoles);
                    await _userManager.AddToRoleAsync(user, "Member");
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var item in register.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View();
        }
    }
}
