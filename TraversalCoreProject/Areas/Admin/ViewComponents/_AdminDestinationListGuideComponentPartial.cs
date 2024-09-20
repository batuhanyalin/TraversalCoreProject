using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;

namespace TraversalCoreProject.Areas.Admin.ViewComponents
{
    public class _AdminDestinationListGuideComponentPartial : ViewComponent
    {
        private readonly IDestinationMatchGuideService _destinationMatchGuideService;

        public _AdminDestinationListGuideComponentPartial(IDestinationMatchGuideService destinationMatchGuideService)
        {
            _destinationMatchGuideService = destinationMatchGuideService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values= _destinationMatchGuideService.TGetGuideAllByDestinationId(id);
            return View(values);
        }
    }
}
