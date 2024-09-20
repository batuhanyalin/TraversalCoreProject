﻿using Microsoft.EntityFrameworkCore;
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
    }
}
