using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.BusinessLayer.Abstract;

namespace TraversalCoreProject.ViewComponents
{
    public class _DestinationDetailTagsComponentPartial : ViewComponent
    {
        private readonly IDestinationTagService _destinationTagService;

        public _DestinationDetailTagsComponentPartial(IDestinationTagService destinationTagService)
        {
            _destinationTagService = destinationTagService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values= _destinationTagService.TGetTagsAllByDestinationId(id);
            return View(values);
        }
    }
}
