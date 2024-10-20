using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;

namespace TraversalCoreProject.ViewComponents
{
    public class _FeaturePostsComponentPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly IMapper _mapper;

        public _FeaturePostsComponentPartial(IDestinationService destinationService, IMapper mapper)
        {
            _destinationService = destinationService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetFeaturePosts().OrderByDescending(x=>x.DestinationId);
            var values2 = _destinationService.TGetFeaturePosts();
            var map = _mapper.Map<List<FeaturePostListDto>>(values);
            var featurePostFirst = values2.FirstOrDefault();
            if (featurePostFirst == null) { 
                
            }
            else
            {
                ViewBag.fpDestinationId=featurePostFirst.DestinationId;
                ViewBag.fpCountry = "KITA - ÜLKE";
                ViewBag.fpCity = featurePostFirst.CityId;
                ViewBag.fpPrice = featurePostFirst.Price;
                ViewBag.fpDayNight = featurePostFirst.DayNight;
                ViewBag.fpImageUrl = featurePostFirst.ImageUrl;
                ViewBag.fpDescription = featurePostFirst.Description;
            }
            return View(map);
        }
    }
}

