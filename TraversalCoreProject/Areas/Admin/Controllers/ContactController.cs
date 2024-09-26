using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.AdminAreaDtos.ContactDtos;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [Route("IsApproved/{id:int}")]
        public IActionResult IsApproved(int id)
        {
            _contactService.TIsApprovedByContactId(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("DeleteContact/{id:int}")]
        public IActionResult DeleteContact(int id)
        {
            _contactService.TDelete(id);
            return Json(new { success = true });
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values= _contactService.TGetListAll();
            var map= _mapper.Map<List<ContactListDto>>(values);
            return View(map);
        }
        [Route("ReadContactMessage/{id:int}")]
        public IActionResult ReadContactMessage(int id)
        {
            var values = _contactService.TGetById(id);
            var map = _mapper.Map<ContactListDto>(values);
            return View(map);
        }
    }
}
