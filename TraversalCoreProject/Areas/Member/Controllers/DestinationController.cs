using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    [Route("Member/[controller]")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IMapper _mapper;

        public DestinationController(IDestinationService destinationService, IMapper mapper)
        {
            _destinationService = destinationService;
            _mapper = mapper;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values= _destinationService.TGetAllDestinationWithAllInfo();
            var map = _mapper.Map<List<DestinationListDto>>(values);
            return View(map);
        }
    }
}
