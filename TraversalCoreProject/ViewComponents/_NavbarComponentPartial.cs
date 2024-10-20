using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.EntityLayer.Concrete;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.ViewComponents
{
    public class _NavbarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _NavbarComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var authentication = User.Identity.Name;
            if (authentication != null)
            {
                var user = await _userManager.FindByNameAsync(authentication);
                var userRole = await _userManager.GetRolesAsync(user);
                FooterAuthenticationControllerModel model = new FooterAuthenticationControllerModel();
                model.Role = userRole.FirstOrDefault();
                model.IdentityName = authentication;
                return View(model);
            }
            FooterAuthenticationControllerModel model2 = new FooterAuthenticationControllerModel();
            return View(model2);
        }
    }
}
