using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.BusinessLayer.ValidationRules;
using TraversalCoreProject.DtoLayer.DefaultDtos.ContactDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactCreateDto contactCreateDto)
        {
            ContactCreateValidator validationRules = new ContactCreateValidator();
            var validator = validationRules.Validate(contactCreateDto);
            if (!validator.IsValid)
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(contactCreateDto);
            }
            else
            {
                contactCreateDto.SendingDate = DateTime.Now;
                contactCreateDto.IsApproved = false;
                var map = _mapper.Map<Contact>(contactCreateDto);
                _contactService.TInsert(map);
                return Json(new { success = true });
            }         
        }
    }
}
