using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.AnnouncementDtos;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.AnnouncementDtos;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]")]
    [Authorize(Roles = "Guide,Member")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values= _announcementService.TGetListAll();
            var map= _mapper.Map<List<MemberAnnouncementListDto>>(values);
            return View(map);
        }

        [Route("AnnouncementDetail/{id:int}")]
        public IActionResult AnnouncementDetail(int id)
        {
            var values = _announcementService.TGetById(id);
            var map = _mapper.Map<MemberAnnouncementListDto>(values);
            return View(map);
        }
    }
}
