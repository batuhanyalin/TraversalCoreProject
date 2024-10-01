using MediatR;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.CQRS.Commands.ContactCommands;
using TraversalCoreProject.CQRS.Queries.ContactQueries;
using TraversalCoreProject.CQRS.Results.ContactResults;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class MediatRContactController : Controller
    {
        private readonly IMediator _mediator;

        public MediatRContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("CreateContact")]
        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }
        [Route("CreateContact")]
        [HttpPost]
        public async Task<ActionResult> CreateContact(CreateContactCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllContactQuery());
            return View(values);
        }
        [Route("GetContact/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetContact(int id)
        {
            var values = await _mediator.Send(new GetContactByIdQuery(id));
            return View(values);
        }
        [Route("UpdateContact")]
        [HttpPost]
        public async Task<IActionResult> UpdateContact(GetContactByIdQueryResult result)
        {
            var value = _mediator.Send(result);
            return View(value);
        }
    }
}
