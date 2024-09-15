using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents
{
    public class _MakingReservationBannerComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
