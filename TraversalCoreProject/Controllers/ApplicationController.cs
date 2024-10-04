using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.RegisterDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class ApplicationController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ApplicationController(IMapper mapper, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(ApplicationDto registerDto)
        {

            ApplicationValidator validationRules = new ApplicationValidator();
            var validation = validationRules.Validate(registerDto);
            if (!validation.IsValid)
            {
                foreach (var item in validation.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(registerDto);
            }
            registerDto.Password = "Deneme.123";
            registerDto.ApplicationDate = DateTime.Now;
            registerDto.IsActive = false;
            var map = _mapper.Map<AppUser>(registerDto);
            map.ImageUrl = $"/images/users/no-image-users.png";
            var result = await _userManager.CreateAsync(map, registerDto.Password);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(registerDto.UserName);
                var currentRoles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, currentRoles);
                await _userManager.AddToRoleAsync(user, "GuideApplication");
                return RedirectToAction("Index", "Default");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
