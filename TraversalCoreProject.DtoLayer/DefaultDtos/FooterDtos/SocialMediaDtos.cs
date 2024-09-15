using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.DefaultDtos.FooterDtos
{
    public class SocialMediaDtos
    {
        public int SocialMediaId { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public string LinkUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
