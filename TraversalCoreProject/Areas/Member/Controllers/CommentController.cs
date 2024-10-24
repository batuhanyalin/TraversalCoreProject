using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]")]
    [Authorize(Roles = "Guide,Member")]
    public class CommentController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(IMapper mapper, ICommentService commentService, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _commentService = commentService;
            _userManager = userManager;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _commentService.TGetListCommentWithAllInfoByMemberId(user.Id);
            var map= _mapper.Map<List<CommentListDto>>(values);
            return View(map);
        }

        [Route("CommentDetail/{id:int}")]
        public IActionResult CommentDetail(int id)
        {
            var value=_commentService.TGetCommenById(id);
            var map= _mapper.Map<CommentListDto>(value);
            return View(map);
        }
    }
}
