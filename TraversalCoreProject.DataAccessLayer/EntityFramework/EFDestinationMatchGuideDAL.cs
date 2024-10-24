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
    public class EFDestinationMatchGuideDAL : GenericRepository<DestinationMatchGuide>, IDestinationMatchGuideDAL
    {
        TraversalContext context = new TraversalContext();
        public List<DestinationMatchGuide> GetGuideAllByDestinationId(int id)
        {
            var values = context.DestinationMatchGuides.Where(x => x.DestinationId == id).Include(x => x.Guide).Include(x => x.Destination).ToList();
            return values;
        }
        public List<DestinationMatchGuide> GetDestinationAllByGuideId(int id)
        {
            var values = context.DestinationMatchGuides.Where(x => x.GuideId == id).Include(x => x.Guide).Include(x => x.Destination).Include(x=>x.Destination.City).ThenInclude(x=>x.Country).ThenInclude(x=>x.Continent).ToList();
            return values;
        }

    }
}
