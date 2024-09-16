using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;

namespace TraversalCoreProject.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IMapper _mapper;

        public DestinationController(IDestinationService destinationService, IMapper mapper)
        {
            _destinationService = destinationService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values=_destinationService.TGetListAll();
            var map= _mapper.Map<List<DestinationListDto>>(values);
            return View(map);
        }
        public IActionResult DestinationDetail(int id)
        {
            return View();
        }
    }
}
