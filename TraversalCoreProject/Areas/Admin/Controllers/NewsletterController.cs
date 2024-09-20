﻿using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class NewsletterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
