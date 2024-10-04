using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.GuideDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IGuideService _guideService;
        private readonly IMapper _mapper;
        public GuideController(UserManager<AppUser> userManager, IMapper mapper, IGuideService guideService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _guideService = guideService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.GetUsersInRoleAsync("Guide");
            var map = _mapper.Map<List<GuideListDto>>(values);
            return View(map);
        }
        public IActionResult GuideDetail(int id)
        {
            var user=_guideService.TGetGuideDetailById(id);
            var map=_mapper.Map<GuideDetailDto>(user);
            return View(map);
        }
    }
}
