using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.AnnouncementDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _announcementService.TGetListAll();
            var map = _mapper.Map<List<AnnouncementListDto>>(values);
            return View(map);
        }
        [HttpPost]
        [Route("DeleteAnnouncement/{id:int}")]
        public IActionResult DeleteAnnouncement(int id)
        {
            _announcementService.TDelete(id);
            return Json(new { success = true });
        }
        [HttpGet]
        [Route("GetAnnouncement/{id:int}")]
        public IActionResult GetAnnouncement(int id)
        {
            var value = _announcementService.TGetById(id);
            var jsonValue = JsonConvert.SerializeObject(value);
            return Json(jsonValue);
        }
        [HttpPost]
        [Route("UpdateAnnouncement")]
        public IActionResult UpdateAnnouncement(Announcement announcement)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(announcement);
                return Json(new { success = true });
            }
            return View(announcement);
        }


        [HttpPost]
        [Route("CreateAnnouncement")]
        public IActionResult CreateAnnouncement(AnnouncementCreateDto announcementCreateDto)
        {
            announcementCreateDto.Date = DateTime.Now;
            AnnouncementValidator validationRules = new AnnouncementValidator();
            var validation = validationRules.Validate(announcementCreateDto);
            if (!validation.IsValid)
            {
                foreach (var item in validation.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(announcementCreateDto);
            }
            else
            {
                var map = _mapper.Map<Announcement>(announcementCreateDto);
                _announcementService.TInsert(map);
                return Json(new { success = true });
            }
        }

    }
}
