using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class CityController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("CityList")]
        public IActionResult CityList()
        {
            var jsonCity= JsonConvert.SerializeObject(cities);
            return Json(jsonCity);
        }

        public static List<CityClass> cities = new List<CityClass>
        {
           new CityClass
            {
            CityId = 1,
            CityName="Üsküp",
            CityCountry="Makedonya"
            },
           new CityClass
            {
             CityId = 2,
            CityName="Roma",
            CityCountry="İtalya"
            },

           new CityClass
            {
             CityId = 3,
            CityName="Londra",
            CityCountry="İngiltere"
            }
        };
    }
}
