using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.MemberDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.GuideDtos;
using TraversalCoreProject.DtoLayer.RegisterDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class GuideController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IGuideService _guideService;
        private IMapper _mapper;

        public GuideController(UserManager<AppUser> userManager, IMapper mapper, IGuideService guideService, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _guideService = guideService;
            _roleManager = roleManager;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.GetUsersInRoleAsync("Guide");
            var map = _mapper.Map<List<GuideListDto>>(values);
            return View(map);
        }
        [HttpGet]
        [Route("CreateGuide")]
        public IActionResult CreateGuide()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateGuide")]
        public async Task<IActionResult> CreateGuide(RegisterDto registerDto)
        {
            var validation = new RegisterValidator().Validate(registerDto);
            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(registerDto);
            }

            registerDto.ApplicationDate = DateTime.Now;
            registerDto.IsActive = true;
            if (ModelState.IsValid)
            {
                var value = _mapper.Map<AppUser>(registerDto);
                if (value.ImageUrl == null)
                {
                    value.ImageUrl = $"/images/users/no-image-users.png";
                }

                var register = await _userManager.CreateAsync(value, registerDto.Password);
                if (register.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(registerDto.UserName);
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    await _userManager.RemoveFromRolesAsync(user, currentRoles);
                    await _userManager.AddToRoleAsync(user, "Guide");
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in register.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [Route("IsApproved/{id:int}")]
        public IActionResult IsApproved(int id)
        {
            _guideService.TIsApprovedByUserId(id);
            return RedirectToAction("Index");
        }
        [Route("DeleteGuide/{id:int}")]
        public async Task<IActionResult> DeleteGuide(int id)
        {
            var value = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(value);
            return Json(new { success = true });
        }
        [Route("UpdateGuide/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> UpdateGuide(int id)
        {     var value = await _userManager.FindByIdAsync(id.ToString());

            var currentRole = await _userManager.GetRolesAsync(value);
            var roles = await _roleManager.Roles.ToListAsync();
            List<SelectListItem> rol = (from x in roles.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.Id.ToString(),
                                            Selected=currentRole.Contains(x.Name)
                                        }).ToList();
            ViewBag.userRole = rol;    
            var map = _mapper.Map<MemberUpdateDto>(value); 
            return View(map);
        }
        [Route("UpdateGuide/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> UpdateGuide(MemberUpdateDto memberUpdateDto, IFormFile Image)
        {
            var user = await _userManager.FindByIdAsync(memberUpdateDto.Id.ToString());
            var validator = new MemberUpdateValidatorForAdmin().Validate(memberUpdateDto);
            if (!validator.IsValid)
            {
                memberUpdateDto.ImageUrl = user.ImageUrl;
                foreach (var error in validator.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(memberUpdateDto);
            }
            else
            {
                if (Image != null && Image.Length > 0)
                {
                    var source = Directory.GetCurrentDirectory();
                    var extension = Path.GetExtension(Image.FileName);
                    var imageName = Guid.NewGuid() + extension;
                    var saveLocation = Path.Combine(source, "wwwroot/images/users/", imageName);
                    using (var stream = new FileStream(saveLocation, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }
                    memberUpdateDto.ImageUrl = $"/images/users/{imageName}";
                    user.ImageUrl = memberUpdateDto.ImageUrl;
                }
                else if (user.ImageUrl == null)
                {
                    user.ImageUrl = $"/images/users/no-image-users.png";
                }

                //Rol değiştirme işlemi--
                var currentRole = await _userManager.GetRolesAsync(user);
                var newRole = _roleManager.Roles.FirstOrDefault(x => x.Id == memberUpdateDto.UserRole.Id);
                await _userManager.RemoveFromRolesAsync(user, currentRole);
                await _userManager.AddToRoleAsync(user, newRole.Name);
                //Rol değiştirme işlemi--

                user.Name = memberUpdateDto.Name;
                user.Surname = memberUpdateDto.Surname;
                user.PhoneNumber = memberUpdateDto.Phone;
                user.About = memberUpdateDto.About;
                user.Email = memberUpdateDto.Email;
                user.HomeTown = memberUpdateDto.HomeTown;
                user.MainLanguage = memberUpdateDto.MainLanguage;
                user.OtherLanguage = memberUpdateDto.OtherLanguage;
                user.Birtday = memberUpdateDto.Birtday;
                user.Profession = memberUpdateDto.Profession;
                user.TwitterUrl = memberUpdateDto.TwitterUrl;
                user.InstagramUrl = memberUpdateDto.InstagramUrl;
                if (memberUpdateDto.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, memberUpdateDto.Password);
                    var result1 = await _userManager.UpdateAsync(user);
                    if (result1.Succeeded)
                    {
                        return View(memberUpdateDto);
                    }
                    else
                    {
                        return View();
                    }
                }
                else
                {
                    var result2 = await _userManager.UpdateAsync(user);
                    if (result2.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View();
                    }
                }

            }
        }
    }
}
