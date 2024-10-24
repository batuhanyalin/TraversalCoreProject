using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.RoleDtos;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.TagDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly ITagService _tagService;
        private readonly IDestinationTagService _destinationTagService;
        private readonly IMapper _mapper;

        public TagController(ITagService tagService, IMapper mapper, IDestinationTagService destinationTagService, IDestinationService destinationService)
        {
            _tagService = tagService;
            _mapper = mapper;
            _destinationTagService = destinationTagService;
            _destinationService = destinationService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _tagService.TGetListAll();
            var destinationTag = _destinationTagService.TGetListAll();
            var map = _mapper.Map<List<TagListDto>>(values);
            foreach (var tag in map)
            {
                var destinationMatchTag = _destinationService.TGetAllDestinationByTagId(tag.TagId);
                tag.TagCount = destinationMatchTag.Count();
            }
            return View(map);
        }
        [Route("DeleteTag/{id:int}")]
        [HttpPost]
        public IActionResult DeleteTag(int id)
        {
            var value = _tagService.TGetById(id);
            _tagService.TDelete(value.TagId);
            return Json(new { success = true });
        }
        [Route("UpdateTag")]
        [HttpPost]
        public IActionResult UpdateTag(TagUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                var value = _tagService.TGetById(model.TagId);
                value.TagName = model.TagName;
                _tagService.TUpdate(value);
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false, message = "Etiket bilgileri eksik veya hatalı. Lütfen tekrar deneyin." });
            }
        }
        [Route("CreateTag")]
        [HttpPost]
        public IActionResult CreateTag(TagCreateDto model)
        {
            if (model == null)
            {
                return Json(new { success = false, message = "Etiket adı boş geçilemez." });
            }
                var map = _mapper.Map<Tag>(model);
                _tagService.TInsert(map);
                return Json(new { success = true });
        }
        [Route("GetTag/{id:int}")]
        [HttpGet]
        public IActionResult GetTag(int id)
        {
            var value = _tagService.TGetById(id);
            var jsonValue = JsonConvert.SerializeObject(value);
            return Json(jsonValue);
        }
    }
}
