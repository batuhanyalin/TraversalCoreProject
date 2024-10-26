using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;

namespace TraversalCoreProject.ViewComponents
{
    public class _MakingReservationBannerComponentPartial : ViewComponent
    {
        private readonly IContinentService _continentService;

        public _MakingReservationBannerComponentPartial(IContinentService continentService)
        {
            _continentService = continentService;
        }
        public IViewComponentResult Invoke()
        {
            var value = _continentService.TGetListAll();

            List<SelectListItem> contList = (from x in value.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ContinentName,
                                                Value = x.ContinentId.ToString()
                                            }).ToList();
            ViewBag.continent = contList;
            return View();
        }
    }
}
