using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.EntityLayer.Concrete
{
    public class DestinationMatchGuide
    {
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public int GuideId { get; set; }
        public Guide Guide { get; set; }
    }
}
