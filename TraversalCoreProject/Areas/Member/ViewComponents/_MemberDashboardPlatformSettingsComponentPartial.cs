using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ProfileDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Member.ViewComponents
{
    public class _MemberDashboardPlatformSettingsComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public _MemberDashboardPlatformSettingsComponentPartial(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    
    }
}
