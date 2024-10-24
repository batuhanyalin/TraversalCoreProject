using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProject.Areas.Admin.Models
{
    public class ContinentCountryCityViewModel
    {
        public IEnumerable<SelectListItem> City { get; set; }
        public IEnumerable<SelectListItem> Country { get; set; }
        public IEnumerable<SelectListItem> Continent { get; set; }
    }
}
