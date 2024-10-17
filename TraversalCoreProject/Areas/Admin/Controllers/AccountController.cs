using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Admin.Models;
using TraversalCoreProject.BusinessLayer.Abstract.AbstractUow;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("Index")]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender= _accountService.TGetById(model.SenderId);
            var valueReceiver= _accountService.TGetById(model.ReceiverId);
            valueSender.Balance -=model.Amount;
            valueReceiver.Balance +=model.Amount;
            List<Account> modifiedAccounts = new List<Account>() //Burada liste oluşturup objeleri liste halinde döndürüyoruz.
            {
                valueReceiver,
                valueSender
            };

            _accountService.TMultiUpdate(modifiedAccounts);

            return RedirectToAction("Index");
        }
    }
}
