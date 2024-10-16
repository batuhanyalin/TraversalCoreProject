﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using TraversalCoreProject.Areas.Admin.Models;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.MemberDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.RoleDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RoleController(RoleManager<AppRole> roleManager, IMapper mapper, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _mapper = mapper;
            _userManager = userManager;
        }
        [Route("AssignRole/{id:int}")]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var userRoles = await _userManager.GetRolesAsync(user);

            var roles = _roleManager.Roles.ToList();
            List<SelectListItem> userRole= (from x in roles.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.Name,
                                                Value=x.Id.ToString()
                                            }).ToList();
            ViewBag.userRole= userRole;

            //List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();
            //foreach (var item in roles)
            //{
            //    RoleAssignViewModel model = new RoleAssignViewModel();
            //    model.RoleId = item.Id;
            //    model.RoleName = item.Name;
            //    model.RoleExist = userRoles.Contains(item.Name);
            //    roleAssignViewModels.Add(model);
            //}
            return View();
        }

        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = _roleManager.Roles.ToList();
            var roles = _mapper.Map<List<RoleListDto>>(values);
            foreach (var role in roles)
            {
                var userInRole = await _userManager.GetUsersInRoleAsync(role.Name);
                role.UserCount = userInRole.Count();
            }
            return View(roles);
        }
        [HttpGet]
        [Route("GetRole/{id:int}")]
        public async Task<IActionResult> GetRole(int id)
        {
            var value = await _roleManager.FindByIdAsync(id.ToString());
            var jsonValue = JsonConvert.SerializeObject(value);
            return Json(jsonValue);
        }
        [HttpPost]
        [Route("UpdateRole")]
        public async Task<IActionResult> UpdateRole(AppRole role)
        {
            if (ModelState.IsValid)
            {
                var value = await _roleManager.FindByIdAsync(role.Id.ToString());
                value.Name = role.Name;
                await _roleManager.UpdateAsync(value);
                return Json(new { success = true });
            }
            return View(role);
        }
        [Route("UserListByRole/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> UserListByRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            ViewBag.role = role.Name;
            var values = await _userManager.GetUsersInRoleAsync(role.Name);
            var map = _mapper.Map<List<MemberListDto>>(values);
            return View(map);
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(RoleCreateDto roleCreateDto)
        {
            if (roleCreateDto == null)
            {
                return Json(new { success = false, message = "Rol adı boş geçilemez." });
            }

            var map = _mapper.Map<AppRole>(roleCreateDto);
            var result = await _roleManager.CreateAsync(map);
            if (result.Succeeded)
            {
                return Json(new { success = true, message = "Yeni rol başarıyla oluşturuldu." });
            }
            else
            {
                return Json(new { success = false, message = "Rol kaydetme işlemi sırasında bir hata oluştu" });
            }
        }
        [Route("DeleteRole/{id:int}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(values);
            return Json(new { success = true });
        }
    }
}
