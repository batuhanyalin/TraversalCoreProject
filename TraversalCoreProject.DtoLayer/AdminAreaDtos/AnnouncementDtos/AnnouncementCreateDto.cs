using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.AdminAreaDtos.AnnouncementDtos
{
    public class AnnouncementCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }
        public DateTime Date { get; set; }
    }
}
