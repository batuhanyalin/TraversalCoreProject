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
            var value = _indexBannerService.TGetListAll().Where(x => x.IsApproved == true).OrderBy(x => x.IndexBannerId).FirstOrDefault();
            var map = _mapper.Map<IndexBannerShowDto>(value);
            if (map != null)
            {
                return View(map);
            }
            else
            {
                IndexBannerShowDto nullModel= new IndexBannerShowDto();
                nullModel.Title= string.Empty;
                nullModel.Description= string.Empty;
                return View(nullModel);
            }
          
        }
    }
}

