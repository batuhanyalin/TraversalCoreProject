using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDAL _testimonialDAL;

        public TestimonialManager(ITestimonialDAL testimonialDAL)
        {
            _testimonialDAL = testimonialDAL;
        }

        public void TDelete(int id)
        {
           _testimonialDAL.Delete(id);
        }

        public Testimonial TGetById(int id)
        {
            return _testimonialDAL.GetById(id);
        }

        public List<Testimonial> TGetListAll()
        {
            return _testimonialDAL.GetListAll();
        }

        public void TInsert(Testimonial entity)
        {
            _testimonialDAL.Insert(entity);
        }

        public Testimonial TIsApprovedByTestimonialId(int id)
        {
           return _testimonialDAL.IsApprovedByTestimonialId(id);
        }

        public void TMultiUpdate(List<Testimonial> t)
        {
            _testimonialDAL.MultiUpdate(t);
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonialDAL.Update(entity);
        }
    }
}
