using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.AdminAreaDtos.SocialMediaDtos
{
    public class SocialMediaListDto
    {
        public int SocialMediaId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string LinkUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
