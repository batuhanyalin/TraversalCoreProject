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
            var values = _destinationService.TGetListAll();
            var jsonCity = JsonConvert.SerializeObject(values);
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
        [HttpGet]
        [Route("GetDestination")]
        public IActionResult GetDestination(int id)
        {
            var value = _destinationService.TGetById(id);
            var jsonConvert = JsonConvert.SerializeObject(value);
            return Json(jsonConvert);
        }
        [HttpPost]
        [Route("DeleteDestination")]
        public async Task<IActionResult> DeleteDestination(int id)
        {
            var value = _destinationService.TGetById(id);
            _destinationService.TDelete(value.DestinationId);
            return NoContent();

        }
        [HttpPost]
        [Route("UpdateDestination")]
        public async Task<IActionResult> UpdateDestination(Destination destination)
        {
            var values = _destinationService.TGetById(destination.DestinationId);
            destination.Text1 = values.Text1;
            destination.Detail = values.Detail;
            destination.Description = values.Description;
            destination.IsFeaturePost = values.IsFeaturePost;
            destination.Status = values.Status;
            destination.StartDate = values.StartDate;
            destination.Capacity = values.Capacity;
            destination.Price = values.Price;
            destination.CoverImage = values.CoverImage;
            destination.ImageUrl = values.ImageUrl;
            destination.DayNight = values.DayNight;
            _destinationService.TUpdate(destination);
            var jsonValue = JsonConvert.SerializeObject(destination);
            return Json(jsonValue);
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
