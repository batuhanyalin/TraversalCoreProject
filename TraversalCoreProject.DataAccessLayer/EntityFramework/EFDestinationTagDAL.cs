using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DataAccessLayer.Repositories;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.EntityLayer.Concrete;
using TraversalCoreProject.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace TraversalCoreProject.DataAccessLayer.EntityFramework
{
    public class EFDestinationTagDAL:GenericRepository<DestinationTag>,IDestinationTagDAL
    {
        TraversalContext context= new TraversalContext();
        public List<DestinationTag> GetTagsAllByDestinationId(int id)
        {
            var values = context.DestinationTags.Where(x => x.DestinationId == id).Include(x => x.Tag).Include(x => x.Destination).ToList();
            return values;
        }
    }
}
