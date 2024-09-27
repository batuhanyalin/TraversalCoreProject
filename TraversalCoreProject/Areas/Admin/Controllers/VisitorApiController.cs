using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory; //CORS consume edebilmek için field oluşturuyoruz.

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient(); //Client oluşturuyoruz.
            var responseMessage = await client.GetAsync("http://localhost:5270/api/Visitor");
            if (responseMessage.IsSuccessStatusCode) //Eğer başarılı bir success code dönerse           
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //İlgili içeriği okutuyoruz.
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData); //Oluşturulan model içerisine Json verisini deserialize ederek dolduruyoruz.
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateVisitor")]
        public IActionResult CreateVisitor()
        {

            return View();
        }
        [HttpPost]
        [Route("CreateVisitor")]
        public async Task<IActionResult> CreateVisitor(VisitorViewModel visitorViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(visitorViewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json"); //Burada içerik oluşturuluyor
            var responseMessage = await client.PostAsync("http://localhost:5270/api/Visitor", content); // buraya dönüştürülmüş veriyi post ediyoruz.
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        [Route("UpdateVisitor/{id:int}")]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5270/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateVisitor/{id:int}")]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel visitorViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(visitorViewModel);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json"); //Burada içerik oluşturuluyor
            var responseMessage = await client.PutAsync("http://localhost:5270/api/Visitor", content); // buraya dönüştürülmüş veriyi post ediyoruz.
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [Route("DeleteVisitor/{id:int}")]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5270/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

