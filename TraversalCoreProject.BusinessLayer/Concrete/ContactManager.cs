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
    public class ContactManager : IContactService
    {
        private readonly IContactDAL _contactDAL;

        public ContactManager(IContactDAL contactDAL)
        {
            _contactDAL = contactDAL;
        }

        public void TDelete(int id)
        {
            _contactDAL.Delete(id);
        }

        public Contact TGetById(int id)
        {
            return _contactDAL.GetById(id);
        }

        public List<Contact> TGetListAll()
        {
            return _contactDAL.GetListAll();
        }

        public void TInsert(Contact entity)
        {
            _contactDAL.Insert(entity);
        }

        public Contact TIsApprovedByContactId(int id)
        {
            return _contactDAL.IsApprovedByContactId(id);
        }

        public void TMultiUpdate(List<Contact> t)
        {
            _contactDAL.MultiUpdate(t);
        }

        public void TUpdate(Contact entity)
        {
            _contactDAL.Update(entity);
        }
    }
}
