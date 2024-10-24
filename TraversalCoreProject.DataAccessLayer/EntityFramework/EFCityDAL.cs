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
    public class EFCityDAL:GenericRepository<City>, ICityDAL
    {
        TraversalContext context= new TraversalContext();   
        public List<City> GetAllCity()
        {
            var values= context.Cities.Include(x=>x.Country).ThenInclude(x=>x.Continent).ToList();
            return values;
        }
    }
}
