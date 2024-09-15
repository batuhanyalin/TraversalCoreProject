using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.EntityLayer.Concrete
{
    public class DestinationMatchGuide
    {
        public int DestinationMatchGuideId { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }
        public AppUser Guide { get; set; }
        public int GuideId { get; set; }
        
    }
}
