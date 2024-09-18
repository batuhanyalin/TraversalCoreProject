using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos
{
    public class DestinationListDto
    {
        public int DestinationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public DateTime StartDate { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string CoverImage { get; set; }
        public string Text1 { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
        public bool IsFeaturePost { get; set; }
        public List<DestinationTag> DestinationTags { get; set; }
        public List<Comment> Comments { get; set; }
        public List<DestinationMatchGuide> DestinationMatchGuides { get; set; }
    }
}
