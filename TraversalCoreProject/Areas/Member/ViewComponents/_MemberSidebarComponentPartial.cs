﻿using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.ViewComponents
{
    public class _MemberSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}