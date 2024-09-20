using Microsoft.EntityFrameworkCore;
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
    public class EFGuideDAL:GenericRepository<AppUser>,IGuideDAL
    {
        TraversalContext context = new TraversalContext();
        public AppUser GetGuideDetailById(int id)
        {
            var value= context.Users.Where(x=>x.Id==id).Include(x=>x.DestinationMatchGuides).FirstOrDefault();
            return value;
        }
    }
}
