using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ProfileDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Member.ViewComponents
{
    public class _MemberDashboardProfileNavbarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public _MemberDashboardProfileNavbarComponentPartial(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var map= _mapper.Map<MyProfileUpdateDto>(user);
            return View(map);
        }
    }
}
