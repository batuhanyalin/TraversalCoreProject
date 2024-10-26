using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;

namespace TraversalCoreProject.ViewComponents
{
    public class _PopularDestinationsComponentPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly IMapper _mapper;
        public _PopularDestinationsComponentPartial(IDestinationService destinationService, IMapper mapper)
        {
            _destinationService = destinationService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetAllDestinationWithAllInfo();
            var map = _mapper.Map<List<PopularDestinationListDto>>(values);
            return View(map);
        }
    }
}
