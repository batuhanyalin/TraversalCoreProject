using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.FooterDtos;

namespace TraversalCoreProject.ViewComponents
{
    public class _FooterSocialMediaComponentPartial : ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        public _FooterSocialMediaComponentPartial(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _socialMediaService.TGetListAll().Where(x=>x.IsActive==true);
            var map= _mapper.Map<List<SocialMediaDtos>>(values);
            return View(map);
        }
    }
}
