using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;

namespace TraversalCoreProject.Areas.Admin.ViewComponents
{
    public class _AdminGuideListDestinationComponentPartial : ViewComponent
    {
        private readonly IDestinationMatchGuideService _destinationMatchGuideService;

        public _AdminGuideListDestinationComponentPartial(IDestinationMatchGuideService destinationMatchGuideService)
        {
            _destinationMatchGuideService = destinationMatchGuideService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _destinationMatchGuideService.TGetDestinationAllByGuideId(id);
            return View(values);
        }
    }
}
