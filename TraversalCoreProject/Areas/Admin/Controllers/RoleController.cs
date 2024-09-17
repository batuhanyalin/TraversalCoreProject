using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.RoleDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{

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
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateDto roleCreateDto)
        {
            if (roleCreateDto == null)
            {
                return Json(new { success = false, message = "Rol adı boş geçilemez." });
            }
            var checkRole = await _roleManager.FindByNameAsync(roleCreateDto.Name);

            if (checkRole.Name == roleCreateDto.Name)
            {
                return Json(new { success = false, message = "Bu rol zaten sisteme kayıtlı." });
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
        public IActionResult DeleteRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = _roleManager.DeleteAsync(values);
            return Json(new { success = true });
        }
    }
}
