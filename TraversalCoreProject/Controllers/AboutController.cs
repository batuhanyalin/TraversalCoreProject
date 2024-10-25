using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.AboutDtos;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IAboutService aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var value= _aboutService.TGetListAll();
            var about= value.FirstOrDefault();
            var map= _mapper.Map<AboutShowDto>(about);
            return View(map);
        }
    }
}
