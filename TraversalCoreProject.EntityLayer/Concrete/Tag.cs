using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.EntityLayer.Concrete
{
    public class Tag
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public List<DestinationTag> DestinationTags { get; set; }
    }
}
