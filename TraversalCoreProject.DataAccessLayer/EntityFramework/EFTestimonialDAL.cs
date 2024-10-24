using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.DataAccessLayer.Repositories;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DataAccessLayer.EntityFramework
{
    public class EFTestimonialDAL:GenericRepository<Testimonial>,ITestimonialDAL
    {
        TraversalContext context = new TraversalContext();
        public Testimonial IsApprovedByTestimonialId(int id)
        {
            var value = context.Testimonials.Where(x => x.TestimonialId == id).FirstOrDefault();
            if (value.IsApproved == false)
            {
                value.IsApproved = true;
            }
            else
            {
                value.IsApproved = false;
            }
            context.SaveChanges();
            return value;
        }
    }
}
