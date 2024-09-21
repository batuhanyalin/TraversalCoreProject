using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Admin.Models;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.ViewComponents.AdminDashboard
{
    public class _AdminDashboardStatisticCard2ComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public _AdminDashboardStatisticCard2ComponentPartial(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _userManager.GetUsersInRoleAsync("Member");
            var Count = values.Count();
            DashboardStatisticCardModel model = new DashboardStatisticCardModel();
            model.StatisticCardCount = Count;
            return View(model);
        }

    }
}
