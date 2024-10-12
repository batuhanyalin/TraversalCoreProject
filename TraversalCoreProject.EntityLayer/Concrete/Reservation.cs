using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.EntityLayer.Concrete
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public AppUser Member { get; set; }
        public int MemberId { get; set; }
        public int PersonCount { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Description { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public int ReservationStatusId { get; set; }
    }
}
