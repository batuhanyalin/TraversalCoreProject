using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.AdminAreaDtos.AboutDtos
{
    public class AboutListDto
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl1 { get; set; }
        public string Title2 { get; set; }
        public string LittleTitle { get; set; }
        public string Description2 { get; set; }
        public bool Status { get; set; }
    }
}
