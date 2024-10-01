using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DataAccessLayer.Context;

namespace TraversalCoreProject.DataAccessLayer.UnitOfWork
{
    public class UowDAL : IUowDAL
    {
        private readonly TraversalContext _context;

        public UowDAL(TraversalContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
