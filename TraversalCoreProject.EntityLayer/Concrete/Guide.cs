using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.EntityLayer.Concrete
{
    public class Guide
    {
        public int GuideId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string MainLanguage {  get; set; } 
        public string OtherLanguage {  get; set; } 
        public string ImageUrl {  get; set; } 
        public string InstagramUrl {  get; set; } 
        public string TwitterUrl {  get; set; } 
        public DateTime Birtday { get; set; }
        public bool IsActive { get; set; }
        public List<DestinationMatchGuide> DestinationMatchGuides { get; set; }
    }
}
