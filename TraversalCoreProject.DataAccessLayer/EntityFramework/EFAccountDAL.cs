using Microsoft.IdentityModel.Tokens;
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
    public class EFAccountDAL:GenericUowRepository<Account>,IAccountDAL
    {
        public EFAccountDAL(TraversalContext context):base(context) //GenericUnitOfWork constructurdaki yapıyı buraya enjekte ediyoruz.
        {
            
        }
    }
}
