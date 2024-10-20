using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public CommentController(ICommentService commentService, IMapper mapper, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _mapper = mapper;
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _commentService.TGetListCommentWithAllInfo();
            var map = _mapper.Map<List<CommentListDto>>(values);
            return View(map);
        }
        [HttpGet]
        [Route("GetCommentListByMember/{id:int}")]
        public async Task<IActionResult> GetCommentListByMember(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var values = _commentService.TGetListCommentWithAllInfoByMemberId(id);
            ViewBag.name = (user.Name + " " + user.Surname);
            ViewBag.ImageUrl = user.ImageUrl;
            var map = _mapper.Map<List<CommentListDto>>(values);
            return View(map);
        }
        [HttpPost]
        [Route("DeleteComment/{id:int}")]
        public IActionResult DeleteComment(int id)
        {
            _commentService.TDelete(id);
            return Json(new { success = true });
        }
        [Route("IsApproved/{id:int}")]
        public IActionResult IsApproved(int id)
        {
            _commentService.TIsApprovedByCommentId(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("ReadComment/{id:int}")]
        public async Task<IActionResult> ReadComment(int id)
        {
            var values = _commentService.TGetCommenById(id);
            var map = _mapper.Map<CommentListDto>(values);
            return View(map);
        }
    }
}
