using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.EntityLayer.Concrete
{
    public class Destination
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
        public List<Reservation> Reservations { get; set; }
        public List<DestinationMatchGuide> DestinationMatchGuides { get; set; }

    }
}
