using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.AboutDtos;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _aboutService.TGetListAll();
            var about = values.FirstOrDefault();
            var map = _mapper.Map<AboutUpdateDto>(about);
            return View(map);
        }
        [HttpPost]
        [Route("Index")]
        public IActionResult Index(AboutUpdateDto dto)
        {
            var value= _aboutService.TGetById(dto.AboutId);
            value.Description = dto.Description;
            _aboutService.TUpdate(value);
            return RedirectToAction("Index");
        }
    }
}
