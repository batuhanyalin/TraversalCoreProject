using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.BusinessLayer.Abstract.AbstractUow;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.UnitOfWork;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.Concrete.ConcreteUow
{
    public class AccountManager : IAccountService

    {
        private readonly IAccountDAL _accountDAL;
        private readonly IUowDAL _uowDAL;
        public AccountManager(IAccountDAL accountDAL, IUowDAL uowDAL)
        {
            _accountDAL = accountDAL;
            _uowDAL = uowDAL;
        }

        public Account TGetById(int id)
        {
           return _accountDAL.GetById(id);
        }

        public void TInsert(Account t)
        {
            _accountDAL.Insert(t);
            _uowDAL.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDAL.MultiUpdate(t);
            _uowDAL.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDAL.Update(t);
            _uowDAL.Save();
        }
    }
}
