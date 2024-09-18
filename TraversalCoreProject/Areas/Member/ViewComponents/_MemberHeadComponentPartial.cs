using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.ViewComponents
{
    public class _MemberHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
   
    }
}
