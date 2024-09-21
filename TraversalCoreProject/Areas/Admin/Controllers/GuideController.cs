using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    }
}
