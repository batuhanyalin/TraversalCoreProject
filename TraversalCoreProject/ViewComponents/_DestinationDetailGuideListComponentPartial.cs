using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.GuideDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.ViewComponents
{
    public class _DestinationDetailGuideListComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationMatchGuideService _destinationMatchGuideService;
        private readonly IMapper _mapper;

        public _DestinationDetailGuideListComponentPartial(UserManager<AppUser> userManager, IMapper mapper, IDestinationMatchGuideService destinationMatchGuideService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _destinationMatchGuideService = destinationMatchGuideService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var values= _destinationMatchGuideService.TGetGuideAllByDestinationId(id);
            return View(values);
        }
    }
}
