using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.DtoLayer.MemberAreaDtos.ReservationDtos;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member([controller]")]
    public class ReservationController : Controller
    {

        [Route("NewReservation")]
        [HttpGet]
        public IActionResult NewReservation()
        {
            return View();
        }
        [Route("NewReservation")]
        [HttpPost]
        public IActionResult NewReservation(MemberNewReservationDto memberNewReservationDto)
        {
            return View();
        }
        [HttpGet]
        [Route("MyCurrentReservation")]
        public IActionResult MyCurrentReservation()
        {
            return View();
        }
        [HttpGet]
        [Route("MyOldReservation")]
        public IActionResult MyOldReservation()
        {
            return View();
        }
    }
}
