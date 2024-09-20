using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ReservationDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]")]
    public class ReservationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IDestinationService _destinationService;
        private readonly IReservationService _reservationService;

        public ReservationController(UserManager<AppUser> userManager, IMapper mapper, IDestinationService destinationService, IReservationService reservationService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _destinationService = destinationService;
            _reservationService = reservationService;
        }

        [Route("NewReservation")]
        [HttpGet]
        public IActionResult NewReservation()
        {
            var destin = _destinationService.TGetAllDestinationWithAllInfo();
            List<SelectListItem> destinationListItem = (from x in destin.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = $"{x.Country} - {x.City} Tarih: {x.StartDate.ToString("dd.MM.yyy")} | Fiyat: {x.Price}$ | Güncel Kapasite: {x.Capacity} ",
                                                            Value = x.DestinationId.ToString()
                                                        }).ToList();
            ViewBag.destinationList = destinationListItem;
            return View();
        }
        [Route("NewReservation")]
        [HttpPost]
        public async Task<IActionResult> NewReservation(AdminNewReservationDto memberNewReservationDto)
        {
            var destin = _destinationService.TGetAllDestinationWithAllInfo();
            List<SelectListItem> destinationListItem = (from x in destin.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = $"{x.Country} - {x.City} Tarih: {x.StartDate.ToString("dd.MM.yyy")} | Fiyat: {x.Price}$ | Güncel Kapasite: {x.Capacity} ",
                                                            Value = x.DestinationId.ToString()
                                                        }).ToList();
            ViewBag.destinationList = destinationListItem;

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var validator = new MemberNewReservationValidator().Validate(memberNewReservationDto);
            if (!validator.IsValid)
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(memberNewReservationDto);
            }
            var findDestination = _destinationService.TGetById(memberNewReservationDto.DestinationId);
            if (findDestination.Capacity < memberNewReservationDto.PersonCount)
            {
                //Burada dto içerisine ekstra validationCode alanı açarak özel olarak istenen mesajı validasyon hatası olarak span içerisine gönderiyorum.
                ModelState.AddModelError("validationCode", "Kişi sayısı kapasitenin üzerinde olamaz.");
                return View();
            }

            memberNewReservationDto.MemberId = user.Id;
            memberNewReservationDto.Status = "Onay Bekliyor";
            memberNewReservationDto.ReservationDate = DateTime.Now;
            int capacity1 = findDestination.Capacity;
            int personCount = memberNewReservationDto.PersonCount;
            int newCapacity = (capacity1 - personCount);
            findDestination.Capacity = newCapacity;
            _destinationService.TUpdate(findDestination);
            var map = _mapper.Map<Reservation>(memberNewReservationDto);
            _reservationService.TInsert(map);
            return RedirectToAction("MyCurrentReservation");
        }
        [HttpGet]
        [Route("MyCurrentReservation")]
        public async Task<IActionResult> MyCurrentReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.TGetMyCurrentReservationListByUserId(user.Id);
            var map = _mapper.Map<List<MemberListMyReservationDto>>(values);
            if (map.Count == 0)
            {
                var error = new List<MemberListMyReservationDto>();
                ViewBag.reservationError = "Aktif Rezervasyonunuz Bulunmamaktadır.";
                return View(error);
            }
            else
            {
                return View(map);
            }

        }
        [HttpGet]
        [Route("MyApprovalReservation")]
        public async Task<IActionResult> MyApprovalReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.TGetMyApprovalReservationListByUserId(user.Id);
            var map = _mapper.Map<List<MemberListMyReservationDto>>(values);
            if (map.Count == 0)
            {
                var error = new List<MemberListMyReservationDto>();
                ViewBag.reservationError = "Onay Bekleyen Rezervasyonunuz Bulunmamaktadır.";
                return View(error);
            }
            else
            {
                return View(map);
            }
        }
        [HttpGet]
        [Route("MyOldReservation")]
        public async Task<IActionResult> MyOldReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.TGetMyOldReservationListByUserId(user.Id);
            var map = _mapper.Map<List<MemberListMyReservationDto>>(values);
            if (map.Count == 0)
            {
                var error = new List<MemberListMyReservationDto>();
                ViewBag.reservationError = "Geçmiş Rezervasyonunuz Bulunmamaktadır.";
                return View(error);
            }
            else
            {
                return View(map);
            }
        }
    }
}
