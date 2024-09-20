using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.ViewComponents
{
    public class _DestinationDetailMakeCommentComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _DestinationDetailMakeCommentComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            CommentCreateDto commentCreateDto = new CommentCreateDto();
            commentCreateDto.DestinationId = id;
            commentCreateDto.MemberId = user.Id;
            return View(commentCreateDto);
        }
    }
}
