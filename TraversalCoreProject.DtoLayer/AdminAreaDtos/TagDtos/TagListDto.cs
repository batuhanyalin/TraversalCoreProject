using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DtoLayer.AdminAreaDtos.TagDtos
{
    public class TagListDto
    {
        public int TagId { get; set; }
        public string TagName { get; set; }
        public int TagCount { get; set; }   
        public List<DestinationTag> DestinationTags { get; set; }
    }
}
