using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.MemberDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AdminController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.GetUsersInRoleAsync("Admin");
            var map = _mapper.Map<List<MemberListDto>>(users);
            return View(map);
        }
    }
}
