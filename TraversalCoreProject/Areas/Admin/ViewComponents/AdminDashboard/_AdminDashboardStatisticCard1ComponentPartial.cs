using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Admin.Models;
using TraversalCoreProject.BusinessLayer.Abstract;

namespace TraversalCoreProject.Areas.Admin.ViewComponents.AdminDashboard
{
    public class _AdminDashboardStatisticCard1ComponentPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _AdminDashboardStatisticCard1ComponentPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetListAll().Count();
            DashboardStatisticCardModel model = new DashboardStatisticCardModel();
            model.StatisticCardCount = values;
            return View(model);
        }
    }
}
