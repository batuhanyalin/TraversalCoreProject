using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;

namespace TraversalCoreProject.Areas.Member.ViewComponents
{
    public class _MemberDashboardLastDestinationsComponentPartial : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly IMapper _mapper;

        public _MemberDashboardLastDestinationsComponentPartial(IDestinationService destinationService, IMapper mapper)
        {
            _destinationService = destinationService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var value = _destinationService.TGetLastDestinationForMemberDashboard();
            var map= _mapper.Map<List<DestinationListDto>>(value);
            return View(map);
        }
    }
}
