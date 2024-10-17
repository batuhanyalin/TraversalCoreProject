using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using TraversalCoreProject.Areas.Admin.Models;
namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class ApiMovieController : Controller
    {
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> apiMoiveList = new List<ApiMovieViewModel>(); //Burada oluşturulan modelden liste türetiliyor.
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "87ebda1640msh1f0710fdc6ebb78p11788djsnc07507e0fe79" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMoiveList = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(apiMoiveList);
            }

        }
    }
}
