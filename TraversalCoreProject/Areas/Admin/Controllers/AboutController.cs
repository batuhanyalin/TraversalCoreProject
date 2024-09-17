using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.AboutDtos;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public IActionResult ListAbout()
        {
            var values = _aboutService.TGetListAll();
            var map = _mapper.Map<List<AboutListDto>>(values);
            return View(map);
        }
    }
}
