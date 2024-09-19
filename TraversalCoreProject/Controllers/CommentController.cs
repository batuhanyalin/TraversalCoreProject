using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public CommentController(ICommentService commentService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> Index(CommentCreateDto commentCreateDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            commentCreateDto.MemberId = user.Id;
            commentCreateDto.IsApproved=false;
            commentCreateDto.CommentDate = DateTime.Now;         
            var map = _mapper.Map<Comment>(commentCreateDto);
            _commentService.TInsert(map);
            return RedirectToAction("DestinationDetail","Destination",new { id = commentCreateDto.DestinationId });         
        }
    }
}
