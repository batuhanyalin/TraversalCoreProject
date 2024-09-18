using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public DestinationController(IDestinationService destinationService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetListAll();
            var map = _mapper.Map<List<DestinationListDto>>(values);
            return View(map);
        }
        public async Task<IActionResult> DestinationDetail(int id)
        {
            var x = User.Identity.Name;
            ViewBag.user = 8;
            ViewBag.id = id;
            var value = _destinationService.TGetById(id);
            var map = _mapper.Map<DestinationListDto>(value);
            return View(map);
        }
    }
}
