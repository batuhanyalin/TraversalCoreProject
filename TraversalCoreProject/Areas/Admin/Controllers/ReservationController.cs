using AutoMapper;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.ReservationDtos;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ReservationDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ReservationController(IReservationService reservationService, IMapper mapper, UserManager<AppUser> userManager, IDestinationService destinationService)
        {
            _reservationService = reservationService;
            _mapper = mapper;
            _userManager = userManager;
            _destinationService = destinationService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _reservationService.TGetListReservationWithAllInfo();
            var map = _mapper.Map<List<AdminListReservationDto>>(values);
            return View(map);
        }
        [HttpGet]
        [Route("GetReservationListByMember/{id:int}")]
        public async Task<IActionResult> GetReservationListByMember(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var values = _reservationService.TGetListReservationWithAllInfoByMemberId(id);
            ViewBag.name = (user.Name + " " + user.Surname);
            ViewBag.ImageUrl = user.ImageUrl;
            var map = _mapper.Map<List<AdminListReservationDto>>(values);
            return View(map);
        }

        [HttpGet]
        [Route("UpdateReservation/{id:int}")]
        public async Task<IActionResult> UpdateReservation(int id)
        {
            var member = _userManager.Users.ToList();
            var value = _reservationService.TGetReservationWithAllInfoById(id);
            var destin = _destinationService.TGetAllDestinationWithAllInfo();
            List<SelectListItem> destinationListItem = (from x in destin.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = $"{x.Country} - {x.City} Tarih: {x.StartDate.ToString("dd.MM.yyy")} | Fiyat: {x.Price}$ | Güncel Kapasite: {x.Capacity} ",
                                                            Value = x.DestinationId.ToString()
                                                        }).ToList();
            List<SelectListItem> memberListItem = (from x in member.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = $"{x.Name} {x.Surname} | Eposta: {x.Email} | Telefon: {x.Phone}",
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.destinationList = destinationListItem;
            ViewBag.memberList = memberListItem;
            var map = _mapper.Map<AdminReservationUpdateDto>(value);
            return View(map);
        }
        [HttpPost]
        [Route("UpdateReservation/{id:int}")]
        public async Task<IActionResult> UpdateReservation(AdminReservationUpdateDto memberNewReservationDto)
        {
            var member = _userManager.Users.ToList();
            var destin = _destinationService.TGetAllDestinationWithAllInfo();
            List<SelectListItem> destinationListItem = (from x in destin.ToList()
                                                        select new SelectListItem
                                                        {
                                                            Text = $"{x.Country} - {x.City} Tarih: {x.StartDate.ToString("dd.MM.yyy")} | Fiyat: {x.Price}$ | Güncel Kapasite: {x.Capacity} ",
                                                            Value = x.DestinationId.ToString()
                                                        }).ToList();
            ViewBag.destinationList = destinationListItem;
            List<SelectListItem> memberListItem = (from x in member.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = $"{x.Name} {x.Surname} | Eposta: {x.Email} | Telefon: {x.Phone}",
                                                       Value = x.Id.ToString()
                                                   }).ToList();
            ViewBag.memberList = memberListItem;

            var validator = new AdminUpdateReservationValidator().Validate(memberNewReservationDto);
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
                ModelState.AddModelError("ReservationError", "Kişi sayısı kapasitenin üzerinde olamaz.");
                return View();
            }
            if (memberNewReservationDto.Status == "Onaylandı")
            {
                int capacity1 = findDestination.Capacity;
                int personCount = memberNewReservationDto.PersonCount;
                int newCapacity = (capacity1 - personCount);
                findDestination.Capacity = newCapacity;
                _destinationService.TUpdate(findDestination);
            }
            Reservation reservation = new Reservation();
            reservation.Status = memberNewReservationDto.Status;
            reservation.PersonCount = memberNewReservationDto.PersonCount;
            reservation.ReservationDate = memberNewReservationDto.ReservationDate;
            reservation.DestinationId = memberNewReservationDto.DestinationId;
            reservation.Description = memberNewReservationDto.Description;
            reservation.MemberId = memberNewReservationDto.MemberId;
            reservation.ReservationId = memberNewReservationDto.ReservationId;
            _reservationService.TUpdate(reservation);
            return RedirectToAction("Index");
        }
    }
}
