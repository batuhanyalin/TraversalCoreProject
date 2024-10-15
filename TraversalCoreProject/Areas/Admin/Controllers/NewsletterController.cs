using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.NewsletterDtos;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;
        private readonly IMapper _mapper;
        public NewsletterController(INewsletterService newsletterService, IMapper mapper)
        {
            _newsletterService = newsletterService;
            _mapper = mapper;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values= _newsletterService.TGetListAll();
            var map =_mapper.Map<List<NewsletterListDto>>(values);
            return View(map);
        }
    }
}
