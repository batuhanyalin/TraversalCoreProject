using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.ViewComponents
{
    public class _DestinationDetailMakeCommentComponentPartial:ViewComponent
    { private readonly UserManager<IdentityUser> _userManager;

        public _DestinationDetailMakeCommentComponentPartial(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public IViewComponentResult Invoke(int id)
        {
            //var user = _userManager.FindByNameAsync(User.Identity.Name);
            CommentCreateDto commentCreateDto = new CommentCreateDto();
            commentCreateDto.DestinationId = id;
            commentCreateDto.MemberId = 4; //user.Id gelecek.
            return View(commentCreateDto);
        }
    }
}
