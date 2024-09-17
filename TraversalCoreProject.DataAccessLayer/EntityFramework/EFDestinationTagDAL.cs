using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DataAccessLayer.Repositories;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DataAccessLayer.EntityFramework
{
    public class EFDestinationTagDAL:GenericRepository<DestinationTag>,IDestinationTagDAL
    {
    }
}
