using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.ViewComponents
{
    public class _AdminFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
