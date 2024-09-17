using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos;

namespace TraversalCoreProject.ViewComponents
{
    public class _DestinationDetailCommentListComponentPartial:ViewComponent
    {
        private readonly  ICommentService _commentService;
        private readonly IMapper _mapper;
        public _DestinationDetailCommentListComponentPartial(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetListAllWithAllInfoByDestinationId(id);
            var map= _mapper.Map<List<CommentListDto>>(values);
            return View(map);
        }
    }
}
