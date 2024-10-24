using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.AnnouncementDtos;

namespace TraversalCoreProject.Areas.Member.ViewComponents
{
    public class _MemberNavbarNotificationComponentPartial : ViewComponent
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public _MemberNavbarNotificationComponentPartial(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values=_announcementService.TGetListAll();
            var map=_mapper.Map<List<MemberAnnouncementListDto>>(values);
            return View(map);
        }
    
    }
}
