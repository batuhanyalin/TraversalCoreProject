using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.DestinationDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class DestinationController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IDestinationMatchGuideService _destinationMatchGuideService;
        private readonly IMapper _mapper;

        public DestinationController(IDestinationService destinationService, IMapper mapper, UserManager<AppUser> userManager, ITagService tagService, IDestinationMatchGuideService destinationMatchGuideService)
        {
            _destinationService = destinationService;
            _mapper = mapper;
            _userManager = userManager;
            _tagService = tagService;
            _destinationMatchGuideService = destinationMatchGuideService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = _destinationService.TGetAllDestinationWithAllInfo();
            var map = _mapper.Map<List<DestinationListDto>>(values);
            return View(map);
        }
        [HttpGet]
        [Route("CreateDestination")]
        public IActionResult CreateDestination()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateDestination")]
        public async Task<IActionResult> CreateDestination(DestinationCreateDto destinationCreateDto, IFormFile ImageUpload, IFormFile CoverImageUpload)
        {
            var validator = new DestinationCreateValidator().Validate(destinationCreateDto);
            if (!validator.IsValid)
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(destinationCreateDto);
            }
            if (ImageUpload != null && ImageUpload.Length > 0)
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(ImageUpload.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(source, "wwwroot/images/destinations/", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await ImageUpload.CopyToAsync(stream);
                }
                destinationCreateDto.ImageUrl = $"/images/destinations/{imageName}";

            }
            if (CoverImageUpload != null && CoverImageUpload.Length > 0)
            {
                var source2 = Directory.GetCurrentDirectory();
                var extension2 = Path.GetExtension(CoverImageUpload.FileName);
                var imageName2 = Guid.NewGuid() + extension2;
                var saveLocation2 = Path.Combine(source2, "wwwroot/images/destinations/", imageName2);
                using (var stream2 = new FileStream(saveLocation2, FileMode.Create))
                {
                    await CoverImageUpload.CopyToAsync(stream2);
                }
                destinationCreateDto.CoverImage = $"/images/destinations/{imageName2}";
            }

            if (ImageUpload == null)
            {
                destinationCreateDto.ImageUrl = $"/images/no-image.jpg";
            }
            if (CoverImageUpload == null)
            {
                destinationCreateDto.CoverImage = $"/images/no-image.jpg";
            }
            var map = _mapper.Map<Destination>(destinationCreateDto);
            _destinationService.TInsert(map);
            return RedirectToAction("Index");
        }
        [Route("DeleteDestination/{id:int}")]
        public IActionResult DeleteDestination(int id)
        {
            _destinationService.TDelete(id);
            return RedirectToAction("Index");
        }
        [Route("UpdateDestination/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> UpdateDestination(int id)
        {
            var guideList = await _userManager.GetUsersInRoleAsync("Guide");
            var tagList = _tagService.TGetListAll();
            var matchGuideList = _destinationMatchGuideService.TGetGuideAllByDestinationId(id);

            var value = _destinationService.TGetById(id);
            var map = _mapper.Map<DestinationUpdateDto>(value);
            return View(map);
        }
        [HttpPost]
        [Route("UpdateDestination/{id}")]
        public async Task<IActionResult> UpdateDestination(DestinationUpdateDto destinationUpdateDto, IFormFile ImageUpload, IFormFile CoverImageUpload)
        {
            var thisDestination = _destinationService.TGetById(destinationUpdateDto.DestinationId);
            var validator = new DestinationUpdateValidator().Validate(destinationUpdateDto);
            if (!validator.IsValid)
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(destinationUpdateDto);
            }
            if (ImageUpload != null && ImageUpload.Length > 0)
            {
                var source = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(ImageUpload.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(source, "wwwroot/images/destinations/", imageName);
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await ImageUpload.CopyToAsync(stream);
                }
                destinationUpdateDto.ImageUrl = $"/images/destinations/{imageName}";
                thisDestination.ImageUrl = destinationUpdateDto.ImageUrl;
            }
            if (CoverImageUpload != null && CoverImageUpload.Length > 0)
            {
                var source2 = Directory.GetCurrentDirectory();
                var extension2 = Path.GetExtension(CoverImageUpload.FileName);
                var imageName2 = Guid.NewGuid() + extension2;
                var saveLocation2 = Path.Combine(source2, "wwwroot/images/destinations/", imageName2);
                using (var stream2 = new FileStream(saveLocation2, FileMode.Create))
                {
                    await CoverImageUpload.CopyToAsync(stream2);
                }
                destinationUpdateDto.CoverImage = $"/images/destinations/{imageName2}";
                thisDestination.CoverImage = destinationUpdateDto.CoverImage;
            }

            if (thisDestination.ImageUrl == null)
            {
                thisDestination.ImageUrl = $"/images/no-image.jpg";
            }
            if (thisDestination.CoverImage == null)
            {
                thisDestination.CoverImage = $"/images/no-image.jpg";
            }

            thisDestination.Capacity = destinationUpdateDto.Capacity;
            thisDestination.Country = destinationUpdateDto.Country;
            thisDestination.City = destinationUpdateDto.City;
            thisDestination.DayNight = destinationUpdateDto.DayNight;
            thisDestination.Description = destinationUpdateDto.Description;
            thisDestination.Text1 = destinationUpdateDto.Text1;
            thisDestination.IsFeaturePost = destinationUpdateDto.IsFeaturePost;
            thisDestination.Status = destinationUpdateDto.Status;
            thisDestination.StartDate = destinationUpdateDto.StartDate;
            thisDestination.Detail = destinationUpdateDto.Detail;
            thisDestination.Price = destinationUpdateDto.Price;
            _destinationService.TUpdate(thisDestination);
            return RedirectToAction("Index");
        }
    }
}
