using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.DestinationDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos;
using TraversalCoreProject.EntityLayer.Concrete;
using Newtonsoft.Json;
using TraversalCoreProject.Areas.Admin.Models;
using DocumentFormat.OpenXml.Office2010.Excel;
using TraversalCoreProject.BusinessLayer.Abstract.AbstractUow;
using DocumentFormat.OpenXml.Presentation;

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
        [Route("IsApproved/{id:int}")]
        public IActionResult IsApproved(int id)
        {
            _destinationService.TIsApprovedByDestinationId(id);
            return RedirectToAction("Index");
        }

        [Route("AddGuideForDestination")]
        [HttpPost]
        public async Task<IActionResult> AddGuideForDestination(List<DestinationMatchGuideViewModel> model)
        {
            var destinationId = TempData["destinationMatchId"];
            var destinationMatchGuideFind = _destinationMatchGuideService.TGetGuideAllByDestinationId(Convert.ToInt32(destinationId));
            var destination = _destinationService.TGetById(Convert.ToInt32(destinationId));
            foreach (var item in model)
            {
                if (item.GuideExist)
                {
                    var existingRecord = _destinationMatchGuideService.TGetGuideAllByDestinationId(item.DestinationId)
.FirstOrDefault(x => x.GuideId == item.GuideId);

                    if (existingRecord == null)
                    {
                        // Eğer böyle bir kayıt yoksa ekleme yap

                        var dmgList = new DestinationMatchGuide();
                        {
                            dmgList.GuideId = item.GuideId;
                            dmgList.DestinationId = item.DestinationId;
                        };
                        _destinationMatchGuideService.TInsert(dmgList);
                    }
                    else
                    {

                    }
                }
                else
                {
                    var destinationMatchGuide = destinationMatchGuideFind.FirstOrDefault(x => x.GuideId == item.GuideId && x.DestinationId == item.DestinationId);
                    if (destinationMatchGuide != null)
                    {
                        _destinationMatchGuideService.TDelete(destinationMatchGuide.DestinationMatchGuideId);
                    }
                }

            }
            return RedirectToAction("Index");
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
        public async Task<IActionResult> CreateDestination()
        {
            // 1. DestinationCreateDto Nesnesi Başlatılıyor
            var destinationCreateDto = new DestinationCreateDto();
            destinationCreateDto.GuideMatchList = new List<DestinationCreateDto.DestinationGuide>();

            // 2. Rehber Listesi Getiriliyor
            var guideList = await _userManager.GetUsersInRoleAsync("Guide");

            // 3. Rehber Bilgileri GuideMatchList Listesine Ekleniyor
            foreach (var item in guideList)
            {
                var model = new DestinationCreateDto.DestinationGuide
                {
                    GuideId = item.Id,
                    GuideName = item.Name + " " + item.Surname,
                    GuideImageUrl = item.ImageUrl,
                    GuideExist = false,
                };
                destinationCreateDto.GuideMatchList.Add(model);
            }
            // 4. DestinationCreateDto Nesnesi View'a Gönderiliyor
            return View(destinationCreateDto);
        }
        [HttpPost]
        [Route("CreateDestination")]
        public async Task<IActionResult> CreateDestination(DestinationCreateDto destinationCreateDto, IFormFile ImageUpload, IFormFile CoverImageUpload)
        {
            // 1. Model Validasyonu
            var validator = new DestinationCreateValidator().Validate(destinationCreateDto);
            if (!validator.IsValid)
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(destinationCreateDto);
            }

            // 2. Resimlerin Yüklenmesi
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

            // 3. Resim yoksa varsayılan resim ayarları
            if (destinationCreateDto.ImageUrl == null)
            {
                destinationCreateDto.ImageUrl = $"/images/no-image.jpg";
            }
            if (destinationCreateDto.CoverImage == null)
            {
                destinationCreateDto.CoverImage = $"/images/no-image.jpg";
            }

            // 4. Yeni Destinasyonun Eklenmesi
            var map = _mapper.Map<Destination>(destinationCreateDto);
            _destinationService.TInsert(map);

            // 5. Yeni Eklenen Destinasyonun Alınması
            var newDestination = _destinationService.TGetById(map.DestinationId);

            // 6. Rehberlerin Eklenmesi veya Silinmesi
            foreach (var guide in destinationCreateDto.GuideMatchList)
            {
                if (guide.GuideExist)
                {
                    var existingRecord = _destinationMatchGuideService.TGetGuideAllByDestinationId(newDestination.DestinationId)
                        .FirstOrDefault(x => x.GuideId == guide.GuideId);

                    if (existingRecord == null)
                    {
                        // Eğer böyle bir kayıt yoksa ekleme yap
                        var dmgList = new DestinationMatchGuide
                        {
                            GuideId = guide.GuideId,
                            DestinationId = newDestination.DestinationId // Yeni Destinasyon Id kullanılıyor
                        };
                        _destinationMatchGuideService.TInsert(dmgList);
                    }
                }
                else
                {
                    // Rehber seçimi kaldırılmışsa, eşleşmeyi sil
                    var destinationMatchGuide = _destinationMatchGuideService.TGetGuideAllByDestinationId(newDestination.DestinationId)
                        .FirstOrDefault(x => x.GuideId == guide.GuideId);
                    if (destinationMatchGuide != null)
                    {
                        _destinationMatchGuideService.TDelete(destinationMatchGuide.DestinationMatchGuideId);
                    }
                }
            }

            // 7. Geri dönüş
            return RedirectToAction("Index");
        }


        [Route("DeleteDestination/{id:int}")]
        [HttpPost]
        public IActionResult DeleteDestination(int id)
        {
            _destinationService.TDelete(id);
            return Json(new { success = true });
        }
        [Route("UpdateDestination/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> UpdateDestination(int id)
        {
            var value = _destinationService.TGetById(id);
        
            var guideList = await _userManager.GetUsersInRoleAsync("Guide");
            var matchGuideList = _destinationMatchGuideService.TGetGuideAllByDestinationId(id);
            List<DestinationUpdateDto.DestinationGuide> destinationMatchGuideViewModels = new List<DestinationUpdateDto.DestinationGuide>();
            foreach (var item in guideList)
            {
                DestinationUpdateDto.DestinationGuide model = new DestinationUpdateDto.DestinationGuide();
                model.GuideId = item.Id;
                model.DestinationId = id;
                model.GuideName = item.Name + " " + item.Surname;
                model.GuideImageUrl = item.ImageUrl;
                model.GuideExist = matchGuideList.Select(x => x.GuideId).Contains(item.Id);
                destinationMatchGuideViewModels.Add(model);
            }            
            var map = _mapper.Map<DestinationUpdateDto>(value);
            map.GuideMatchList = destinationMatchGuideViewModels;
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

            var destinationMatchGuideFind = _destinationMatchGuideService.TGetGuideAllByDestinationId(destinationUpdateDto.DestinationId);

            foreach (var guide in destinationUpdateDto.GuideMatchList)
            {
                if (guide.GuideExist)
                {
                    var existingRecord = _destinationMatchGuideService.TGetGuideAllByDestinationId(guide.DestinationId)
                        .FirstOrDefault(x => x.GuideId == guide.GuideId);

                    if (existingRecord == null)
                    {
                        // Eğer böyle bir kayıt yoksa ekleme yap
                        var dmgList = new DestinationMatchGuide
                        {
                            GuideId = guide.GuideId,
                            DestinationId = guide.DestinationId
                        };
                        _destinationMatchGuideService.TInsert(dmgList);
                    }
                }
                else
                {
                    // Rehber seçimi kaldırılmışsa, eşleşmeyi sil
                    var destinationMatchGuide = destinationMatchGuideFind.FirstOrDefault(x => x.GuideId == guide.GuideId && x.DestinationId == guide.DestinationId);
                    if (destinationMatchGuide != null)
                    {
                        _destinationMatchGuideService.TDelete(destinationMatchGuide.DestinationMatchGuideId);
                    }
                }
            }

            // 4. Geri dönüş
            return RedirectToAction("Index");
        }
    }
}
