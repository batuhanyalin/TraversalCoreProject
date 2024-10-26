using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.Models
{
    public class SearchReservationDefaultViewModel
    {
        public int ContinentId { get; set; }
        public City City { get; set; }
        public DateTime DestinationDate { get; set; }
    }
}
