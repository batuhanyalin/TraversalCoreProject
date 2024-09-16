using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.RoleDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.StatisticDataDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.ViewComponents
{
    public class _StatisticDataComponentPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IMapper _mapper;

        public _StatisticDataComponentPartial(IDestinationService destinationService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper)
        {
            _destinationService = destinationService;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var guides = await _userManager.GetUsersInRoleAsync("Guide");
            var member = await _userManager.GetUsersInRoleAsync("Member");
            var destinations = _destinationService.TGetListAll();

            var destinationCount = destinations.Count();
            var guideCount = guides.Count();
            var memberCount = member.Count();

            StatisticDataShowDto statisticDataShowDto = new StatisticDataShowDto()
            {
                MemberCount = memberCount,
                GuideCount = guideCount,
                DestinationCount = destinationCount,
                RewardCount = 28,
            };  
            return View(statisticDataShowDto);
        }
    }
}

