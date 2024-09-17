using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.EntityLayer.Concrete
{
    public class DestinationTag
    {
        public int DestinationTagId { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}
