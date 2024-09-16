using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.IndexBannerDtos;

namespace TraversalCoreProject.ViewComponents
{
    public class _IndexBannerComponentPartial : ViewComponent
    {
        private readonly IIndexBannerService _indexBannerService;
        private readonly IMapper _mapper;

        public _IndexBannerComponentPartial(IIndexBannerService indexBannerService, IMapper mapper)
        {
            _indexBannerService = indexBannerService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var value = _indexBannerService.TGetListAll().FirstOrDefault();
            var map = _mapper.Map<IndexBannerShowDto>(value);
            return View(map);
        }
    }
}

