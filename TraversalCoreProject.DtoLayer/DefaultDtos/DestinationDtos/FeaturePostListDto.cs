using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.DefaultDtos.DestinationDtos
{
    public class FeaturePostListDto
    {
        public int DestinationId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public string DayNight { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
