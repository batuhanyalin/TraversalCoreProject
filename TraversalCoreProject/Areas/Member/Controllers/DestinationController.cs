using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.DestinationDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]")]
    [Authorize(Roles = "Guide,Member")]
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
            var values = _destinationService.TGetAllDestinationWithAllInfo();
            var map = _mapper.Map<List<DestinationListDto>>(values);
            return View(map);
        }
        //Arama Metodu
        //[Route("GetCitiesSearchByName")]
        //public IActionResult GetCitiesSearchByName(string searchString)
        //{
        //    ViewData["CurrentFilter"]=searchString;
        //    var values = from x in _destinationService.TGetListAll() select x;
        //    if (searchString==null)
        //    {
        //       return RedirectToAction("Index");
        //    }
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        var lowerSearchString = searchString.ToLower();
        //        values = values.Where(x => x.City.ToLower().Contains(lowerSearchString) ||
        //                      x.Country.ToLower().Contains(lowerSearchString));
        //    }
        //    var map = _mapper.Map<List<DestinationListDto>>(values.ToList());
        //    return View(map);
        //}
    }
}


