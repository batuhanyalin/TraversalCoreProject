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
    public class EFDestinationDAL : GenericRepository<Destination>, IDestinationDAL
    {
        TraversalContext context = new TraversalContext();

        public List<Destination> GetAllDestinationByApproved()
        {
            var values = context.Destinations.Where(x=>x.Status==true).Include(x => x.DestinationMatchGuides).Include(x => x.Comments).Include(x => x.DestinationTags).ToList();
            return values;
        }
        public List<Destination> GetFeaturePosts()
        {
            var values = context.Destinations.Where(x => x.IsFeaturePost == true).ToList();
            return values;
        }
        public List<Destination> GetAllDestinationWithAllInfo()
        {
            var values = context.Destinations.Include(x => x.DestinationMatchGuides).Include(x => x.Comments).Include(x => x.DestinationTags).ToList();
            return values;
        }
        public List<DestinationTag> GetAllDestinationByTagId(int id)
        {
            var values = context.DestinationTags.Where(x=>x.TagId==id).Include(x=>x.Destination).Include(x=>x.Tag).ToList();
            return values;
        }
        public Destination IsApprovedByDestinationId(int id)
        {
            var value= context.Destinations.Where(x=>x.DestinationId==id).FirstOrDefault();
            if (value.Status==false)
            {
                value.Status = true;
            }
            else
            {
                value.Status=false;
            }
            context.SaveChanges();
            return value;
        }
    }
}
