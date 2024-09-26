using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.EntityLayer.Concrete;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [AllowAnonymous]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("CityList")]
        public IActionResult CityList()
        {
            var values= _destinationService.TGetListAll();
            var jsonCity= JsonConvert.SerializeObject(values);
            return Json(jsonCity);
        }
        [HttpPost]
        [Route("AddDestination")]
        public async Task<IActionResult> AddDestination(Destination destination)
        {
            destination.Status = true;
            destination.StartDate = DateTime.Now;
            destination.ImageUrl = "ImageUrl";
            destination.CoverImage = "CoverImageUrl";
            destination.Text1 = "text1";
            destination.Detail = "detail";
            destination.Description = "description";
            destination.IsFeaturePost = false;
           _destinationService.TInsert(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }
       


        //public static List<CityClass> cities = new List<CityClass>
        //{
        //   new CityClass
        //    {
        //    CityId = 1,
        //    CityName="Üsküp",
        //    CityCountry="Makedonya"
        //    },
        //   new CityClass
        //    {
        //     CityId = 2,
        //    CityName="Roma",
        //    CityCountry="İtalya"
        //    },

        //   new CityClass
        //    {
        //     CityId = 3,
        //    CityName="Londra",
        //    CityCountry="İngiltere"
        //    }
        //};
    }
}
