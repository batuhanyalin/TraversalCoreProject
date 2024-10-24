using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.IndexBannerDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class IndexBannerController : Controller
    {
        private readonly IIndexBannerService _indexBannerService;
        private readonly IMapper _mapper;

        public IndexBannerController(IIndexBannerService indexBannerService, IMapper mapper)
        {
            _indexBannerService = indexBannerService;
            _mapper = mapper;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _indexBannerService.TGetListAll();
            var map = _mapper.Map<List<IndexBannerListDto>>(values);
            return View(map);
        }

        [Route("GetIndexBanner/{id:int}")]
        [HttpGet]
        public IActionResult GetIndexBanner(int id)
        {
            var value = _indexBannerService.TGetById(id);
            var jsonValue = JsonConvert.SerializeObject(value);
            return Json(jsonValue);
        }
        [HttpPost]
        [Route("UpdateIndexBanner")]
        public IActionResult UpdateIndexBanner(IndexBannerUpdateDto dto)
        {
            if (dto == null)
            {
                return Json(new { success = false, message = "Veriler boş bırakılamaz." });
            }
            var value = _indexBannerService.TGetById(dto.IndexBannerId);
            value.Title = dto.Title;
            value.Description = dto.Description;
            _indexBannerService.TUpdate(value);
            return Json(new { success = true });
        }
        [HttpPost]
        [Route("CreateIndexBanner")]
        public IActionResult CreateIndexBanner(IndexBannerCreateDto dto)
        {
            if (dto == null)
            {
                return Json(new { success = false, message = "Veriler boş bırakılamaz." });
            }
            var map = _mapper.Map<IndexBanner>(dto);
            _indexBannerService.TInsert(map);
            return Json(new { success = true });
        }
        [HttpPost]
        [Route("DeleteIndexBanner/{id:int}")]
        public IActionResult DeleteIndexBanner(int id)
        {
            _indexBannerService.TDelete(id);
            return Json(new { success = true });
        }
        [Route("IsApproved/{id:int}")]
        public IActionResult IsApproved(int id)
        {
            _indexBannerService.TIsApprovedByIndexBannerId(id);
            return RedirectToAction("Index");
        }
    }
}
