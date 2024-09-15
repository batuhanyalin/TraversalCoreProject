using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents
{
    public class _FeaturePostsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}

