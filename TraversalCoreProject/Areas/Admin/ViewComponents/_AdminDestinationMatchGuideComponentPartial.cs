using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Admin.Models;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.ViewComponents
{
    public class _AdminDestinationMatchGuideComponentPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationMatchGuideService _destinationMatchGuideService;

        public _AdminDestinationMatchGuideComponentPartial(IDestinationService destinationService, UserManager<AppUser> userManager, IDestinationMatchGuideService destinationMatchGuideService)
        {
            _destinationService = destinationService;
            _userManager = userManager;
            _destinationMatchGuideService = destinationMatchGuideService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var destination = _destinationService.TGetById(id);
            TempData["destinationMatchId"]= destination.DestinationId;
            var guideList = await _userManager.GetUsersInRoleAsync("Guide");
            var matchGuideList = _destinationMatchGuideService.TGetGuideAllByDestinationId(id);
            List<DestinationMatchGuideViewModel> destinationMatchGuideViewModels = new List<DestinationMatchGuideViewModel>();
            foreach (var item in guideList)
            {
                DestinationMatchGuideViewModel model = new DestinationMatchGuideViewModel();
                model.GuideId = item.Id;
                model.DestinationId = id;
                model.GuideName = item.Name + " " + item.Surname;
                model.GuideImageUrl = item.ImageUrl;
                model.GuideExist = matchGuideList.Select(x => x.GuideId).Contains(item.Id);
                destinationMatchGuideViewModels.Add(model);
            }
            return View(destinationMatchGuideViewModels);
        }
    }
}
