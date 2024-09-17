using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.TestimonialDtos;

namespace TraversalCoreProject.ViewComponents
{
    public class _TestimonialComponentPartial : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;
        public _TestimonialComponentPartial(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.TGetListAll();
            var map = _mapper.Map<List<TestimonialListDto>>(values);
            return View(map);
        }
    }
}
