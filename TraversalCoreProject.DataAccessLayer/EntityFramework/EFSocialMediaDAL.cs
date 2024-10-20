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
    public class EFSocialMediaDAL:GenericRepository<SocialMedia>,ISocialMediaDAL
    {
        TraversalContext context = new TraversalContext();
        public SocialMedia IsApprovedBySocialMediaId(int id)
        {
            var value = context.SocialMedias.Where(x => x.SocialMediaId == id).FirstOrDefault();
            if (value.IsActive == false)
            {
                value.IsActive = true;
            }
            else
            {
                value.IsActive = false;
            }
            context.SaveChanges();
            return value;
        }
    }
}
