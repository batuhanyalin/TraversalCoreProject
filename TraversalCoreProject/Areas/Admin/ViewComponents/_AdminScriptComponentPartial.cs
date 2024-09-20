using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.ViewComponents
{
    public class _AdminScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
