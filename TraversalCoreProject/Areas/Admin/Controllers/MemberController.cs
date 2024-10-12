﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.MemberDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class MemberController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IGuideService _guideService;
        private IMapper _mapper;

        public MemberController(UserManager<AppUser> userManager, IMapper mapper, IGuideService guideService, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _guideService = guideService;
            _roleManager = roleManager;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.GetUsersInRoleAsync("Member");
            var map = _mapper.Map<List<MemberListDto>>(values);
            return View(map);
        }
        [Route("IsApproved/{id:int}")]
        public IActionResult IsApproved(int id)
        {
            _guideService.TIsApprovedByUserId(id);
            return RedirectToAction("Index");
        }

        [Route("DeleteMember/{id:int}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var value = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(value);
            return Json(new { success = true });
        }
        [Route("UpdateMember/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> UpdateMember(int id)
        {
            var value = await _userManager.FindByIdAsync(id.ToString());
            var map = _mapper.Map<MemberUpdateDto>(value);
            var currentRole = await _userManager.GetRolesAsync(value);
            var roles = await _roleManager.Roles.ToListAsync();
            List<SelectListItem> rol = (from x in roles.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Name,
                                            Value = x.Id.ToString(),
                                            Selected = currentRole.Contains(x.Name)
                                        }).ToList();
            ViewBag.userRole = rol;
            return View(map);
        }
        [Route("UpdateMember/{id:int}")]
        [HttpPost]
        public async Task<IActionResult> UpdateMember(MemberUpdateDto memberUpdateDto, IFormFile Image)
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
