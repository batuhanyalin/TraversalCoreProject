using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;
using TraversalCoreProject.EntityLayer.Concrete;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly ITagService _tagService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public DestinationController(IDestinationService destinationService, IMapper mapper, UserManager<AppUser> userManager, ITagService tagService)
        {
            _destinationService = destinationService;
            _mapper = mapper;
            _userManager = userManager;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetAllDestinationByApproved();
            var map = _mapper.Map<List<DestinationListDto>>(values);
            return View(map);
        }
        public async Task<IActionResult> DestinationDetail(int id)
        {
            ViewBag.user = User.Identity.Name;
            ViewBag.id = id;
            var value = _destinationService.TGetDestinationById(id);
            var map = _mapper.Map<DestinationListDto>(value);
            return View(map);
        }
        public async Task<IActionResult> DestinationListForTag(int id)
        {
            var tag = _tagService.TGetById(id);
            var values = _destinationService.TGetAllDestinationByTagId(id);
            ViewBag.tagName = tag.TagName;
            return View(values);
        }

        public IActionResult DestinationSearch(SearchReservationDefaultViewModel model)
        {
            var values = _destinationService.TGetAllDestinationWithAllInfo().Where(x => x.City.Country.ContinentId == model.ContinentId && x.StartDate == model.DestinationDate);
            var map = _mapper.Map<List<DestinationListDto>>(values);
            if (map == null)
            {
               map.DefaultIfEmpty();
            }
            ViewBag.count = map.Count();
            return View(map);
        }
    }
}
