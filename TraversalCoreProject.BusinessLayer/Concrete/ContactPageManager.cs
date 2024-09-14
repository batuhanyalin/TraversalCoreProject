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
    public class ContactPageManager : IContactPageService
    {
        private readonly IContactPageDAL _contactPageDAL;

        public ContactPageManager(IContactPageDAL contactPageDAL)
        {
            _contactPageDAL = contactPageDAL;
        }

        public void TDelete(int id)
        {
            _contactPageDAL.Delete(id);
        }

        public ContactPage TGetById(int id)
        {
            return _contactPageDAL.GetById(id);
        }

        public List<ContactPage> TGetListAll()
        {
            return _contactPageDAL.GetListAll();
        }

        public void TInsert(ContactPage entity)
        {
            _contactPageDAL.Insert(entity);
        }

        public void TUpdate(ContactPage entity)
        {
            _contactPageDAL.Update(entity);
        }
    }
}
