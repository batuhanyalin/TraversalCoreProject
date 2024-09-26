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
    public class EFContactDAL : GenericRepository<Contact>,IContactDAL
    {
        TraversalContext context = new TraversalContext();
        public Contact IsApprovedByContactId(int id)
        {
            var value = context.Contacts.Where(x => x.ContactId == id).FirstOrDefault();
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
