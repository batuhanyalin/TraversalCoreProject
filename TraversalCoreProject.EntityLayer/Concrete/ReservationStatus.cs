using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.EntityLayer.Concrete
{
    public class ReservationStatus
    {
        public int ReservationStatusId { get; set; }
        public string ReservationStatusName { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
