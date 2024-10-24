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
    public class EFIndexBannerDAL:GenericRepository<IndexBanner>,IIndexBannerDAL
    {
        TraversalContext context = new TraversalContext();
        public IndexBanner IsApprovedByIndexBannerId(int id)
        {
            var value = context.IndexBanners.Where(x => x.IndexBannerId == id).FirstOrDefault();
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
