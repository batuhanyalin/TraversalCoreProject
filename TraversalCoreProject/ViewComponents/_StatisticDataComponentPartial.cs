﻿using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents
{
    public class _StatisticDataComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}

