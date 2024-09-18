using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.ViewComponents
{
    public class _MemberNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
   
    }
}
