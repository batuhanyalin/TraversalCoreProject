using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.TestimonialDtos;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ProfileDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _testimonialService.TGetListAll();
            var map = _mapper.Map<List<TestimonialListDtoAdmin>>(values);
            return View(map);
        }
        [Route("ReadTestimonial/{id:int}")]
        [HttpGet]
        public IActionResult ReadTestimonial(int id)
        {
            var value= _testimonialService.TGetById(id);
            var map= _mapper.Map<TestimonialListDtoAdmin>(value);
            return View(map);
        }
        [Route("DeleteTestimonial/{id:int}")]
        [HttpPost]
        public IActionResult DeleteTestimonial(int id)
        {
            return RedirectToAction();
        }
        [Route("CreateTestimonial")]
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            return View();
        }
        [Route("CreateTestimonial")]
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(TestimonialCreateDto dto,IFormFile Image)
        {
            if (Image != null && Image.Length > 0)
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(source, "wwwroot/images/users/", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                dto.ClientImageUrl = $"/images/users/{imageName}";
               
            }
            else if (dto.ClientImageUrl == null)
            {
                dto.ClientImageUrl = $"/images/users/no-image-users.png";
            }
            dto.CommentDate = DateTime.Now;
            dto.IsApproved = false;
            var map = _mapper.Map<Testimonial>(dto);
            _testimonialService.TInsert(map);
            return RedirectToAction("Index");
        }
        [Route("UpdateTestimonial/{id:int}")]
        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            return View();
        }
        [Route("UpdateTestimonial")]
        [HttpPost]
        public IActionResult UpdateTestimonial(TestimonialUpdateDto dto)
        {
            return View();
        }
        [Route("IsApproved/{id:int}")]
        public IActionResult IsApproved(int id)
        {
            _testimonialService.TIsApprovedByTestimonialId(id);
            return RedirectToAction("Index");
        }
    }
}
