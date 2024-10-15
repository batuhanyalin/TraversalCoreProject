using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;

namespace TraversalCoreProject.Areas.Member.ViewComponents
{
    public class _MemberDashboardDestinationListGuideComponentPartial : ViewComponent
    {
        private readonly IDestinationMatchGuideService _destinationMatchGuideService;

        public _MemberDashboardDestinationListGuideComponentPartial(IDestinationMatchGuideService destinationMatchGuideService)
        {
            _destinationMatchGuideService = destinationMatchGuideService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _destinationMatchGuideService.TGetGuideAllByDestinationId(id);
            ViewBag.destinationId = id;
            return View(values);
        }
    }
}
