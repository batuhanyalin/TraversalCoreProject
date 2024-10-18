using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.FooterDtos;
using TraversalCoreProject.EntityLayer.Concrete;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly INewsletterService _newsletterService;
        private readonly IMapper _mapper;

        public DefaultController(INewsletterService newsletterService, IMapper mapper)
        {
            _newsletterService = newsletterService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsletterSubscribeDto model)
        {
            if (ModelState.IsValid)
            {
                var value = _newsletterService.TGetListAll();
                var check = value.FirstOrDefault(x => x.Email == model.Email);
                if (check != null)
                {
                    return Json(new { success = false, message = "Bu e-posta bültene zaten kayıtlı." });
                }
                else
                {
                    var map = _mapper.Map<Newsletter>(model);
                    _newsletterService.TInsert(map);
                    return Json(new { success = true });
                }
            }
            if (model != null)
            {
                return Json(new { success = false, message = "E-posta adresi boş geçilemez." });
            }
            else { return Json(new { success = false, message = "E-posta gönderimi sırasında bir hata oluştu." }); }

        }
    }
}

