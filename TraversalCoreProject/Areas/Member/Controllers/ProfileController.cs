using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ProfileDtos;
using TraversalCoreProject.DtoLayer.RegisterDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        public ProfileController(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            var map = _mapper.Map<MyProfileUpdateDto>(value);
            return View(map);
        }
        [Route("Index")]
        [HttpPost]
        public async Task<IActionResult> Index(MyProfileUpdateDto myProfileUpdateDto, IFormFile Image)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var validation = new MemberProfileUpdateValidator().Validate(myProfileUpdateDto);
            if (!validation.IsValid)
            {
                myProfileUpdateDto.ImageUrl = user.ImageUrl;
                foreach (var error in validation.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View(myProfileUpdateDto);
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
                    myProfileUpdateDto.ImageUrl = $"/images/users/{imageName}";
                    user.ImageUrl = myProfileUpdateDto.ImageUrl;
                }
                else if (user.ImageUrl == null)
                {
                    user.ImageUrl = $"/images/users/no-image-users.png";
                }
                user.Name = myProfileUpdateDto.Name;
                user.Surname = myProfileUpdateDto.Surname;
                user.PhoneNumber = myProfileUpdateDto.Phone;
                user.About = myProfileUpdateDto.About;
                user.Email = myProfileUpdateDto.Email;
                user.HomeTown = myProfileUpdateDto.HomeTown;
                user.MainLanguage = myProfileUpdateDto.MainLanguage;
                user.OtherLanguage = myProfileUpdateDto.OtherLanguage;
                user.Birtday = myProfileUpdateDto.Birtday;
                user.Profession = myProfileUpdateDto.Profession;
                user.TwitterUrl = myProfileUpdateDto.TwitterUrl;
                user.InstagramUrl = myProfileUpdateDto.InstagramUrl;
                if (myProfileUpdateDto.Password != null)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, myProfileUpdateDto.Password);
                    var result1 = await _userManager.UpdateAsync(user);
                    if (result1.Succeeded)
                    {
                        await _signInManager.SignOutAsync();
                        return RedirectToAction("Index","Login");
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
