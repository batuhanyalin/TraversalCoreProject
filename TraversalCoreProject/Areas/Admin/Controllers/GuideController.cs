using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.MemberDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.GuideDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class GuideController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private IMapper _mapper;

        public GuideController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.GetUsersInRoleAsync("Guide");
            var map = _mapper.Map<List<GuideListDto>>(values);
            return View(map);
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
        {
            var value = await _userManager.FindByIdAsync(id.ToString());
            var map = _mapper.Map<MemberUpdateDto>(value);
            return View(map);
        }
        [Route("UpdateGuide/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> UpdateGuide(MemberUpdateDto memberUpdateDto,IFormFile Image)
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
