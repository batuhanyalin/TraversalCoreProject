using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.EntityLayer.Concrete
{
    public class Testimonial
    {
        public int TestimonialId { get; set; }
        public AppUser Member { get; set; }
        public int MemberId { get; set; }
        public string Comment { get; set; }
        public DateTime CommentDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
