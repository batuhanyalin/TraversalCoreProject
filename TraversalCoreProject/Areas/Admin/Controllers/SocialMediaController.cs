using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.SocialMediaDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values= _socialMediaService.TGetListAll();
            var map = _mapper.Map<List<SocialMediaListDto>>(values);
            return View(map);
        }
        [Route("IsApproved/{id:int}")]
        public IActionResult IsApproved(int id)
        {
            _socialMediaService.TIsApprovedBySocialMediaId(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("GetSocialMedia/{id:int}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            var jsonValue = JsonConvert.SerializeObject(value);
            return Json(jsonValue);
        }
        [HttpPost]
        [Route("UpdateSocialMedia")]
        public async Task<IActionResult> UpdateSocialMedia(SocialMedia media)
        {
            if (ModelState.IsValid)
            {
                var value = _socialMediaService.TGetById(media.SocialMediaId);
                value.Name = media.Name;
                value.LogoUrl = media.LogoUrl;
                value.SocialMediaId = media.SocialMediaId;
                value.LinkUrl = media.LinkUrl;
               _socialMediaService.TUpdate(value);
                return Json(new { success = true });
            }

            return Json(new {success=false,message="Sosyal medya bilgileri güncellenemedi."});
        }
    }
}
