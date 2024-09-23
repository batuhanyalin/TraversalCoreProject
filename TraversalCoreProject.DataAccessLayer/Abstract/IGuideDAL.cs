using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DataAccessLayer.Abstract
{
    public interface IGuideDAL : IGenericDAL<AppUser>
    {
        public AppUser GetGuideDetailById(int id);
        public AppUser IsApprovedByUserId(int id);
    }
}

