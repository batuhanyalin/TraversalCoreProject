using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DtoLayer.DefaultDtos.CommentDtos
{
    public class CommentListDto
    {
        public int CommentId { get; set; }
        public AppUser Member { get; set; }
        public int MemberId { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }
        public string Text { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
