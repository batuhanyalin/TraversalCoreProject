using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.ViewComponents
{
    public class _DestinationDetailMakeCommentComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            CommentCreateDto commentCreateDto = new CommentCreateDto();
            commentCreateDto.DestinationId = id;
            commentCreateDto.MemberId = 4;
            return View(commentCreateDto);
        }
    }
}
