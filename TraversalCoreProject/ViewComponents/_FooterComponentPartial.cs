using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
