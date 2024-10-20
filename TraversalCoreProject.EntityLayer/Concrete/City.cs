using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.EntityLayer.Concrete
{
    public class City
    {   
        public int CityId { get; set; }
        public string CityName { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
        public List<Destination> Destinations { get; set; }
    }
}
