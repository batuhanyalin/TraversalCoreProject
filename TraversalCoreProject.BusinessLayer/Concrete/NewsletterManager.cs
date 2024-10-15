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
    public class NewsletterManager : INewsletterService
    {
        private readonly INewsletterDAL _newsletterDAL;

        public NewsletterManager(INewsletterDAL newsletterDAL)
        {
            _newsletterDAL = newsletterDAL;
        }

        public void TDelete(int id)
        {
            _newsletterDAL.Delete(id);
        }

        public Newsletter TGetById(int id)
        {
            return _newsletterDAL.GetById(id);
        }

        public List<Newsletter> TGetListAll()
        {
            return _newsletterDAL.GetListAll();
        }

        public void TInsert(Newsletter entity)
        {
            _newsletterDAL.Insert(entity);
        }

        public void TMultiUpdate(List<Newsletter> t)
        {
            _newsletterDAL.MultiUpdate(t);  
        }

        public void TUpdate(Newsletter entity)
        {
            _newsletterDAL.Update(entity);
        }
    }
}
