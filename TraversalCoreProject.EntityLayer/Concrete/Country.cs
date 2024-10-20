using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.EntityLayer.Concrete
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string AreaCode { get; set; }
        public string ReWrite { get; set; }
        public List<City> Cities { get; set; }
        public Continent Continent { get; set; }
        public int ContinentId { get; set; }
    }
}
