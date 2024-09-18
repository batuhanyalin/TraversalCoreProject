using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
	[AllowAnonymous]
	public class errorController : Controller
	{
		public IActionResult error403()
		{
			return View();
		}
		public IActionResult error404()
		{
			return View();
		}
	}
}
