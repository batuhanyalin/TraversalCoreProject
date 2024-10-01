using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Context;

namespace TraversalCoreProject.DataAccessLayer.Repositories
{
    public class GenericUowRepository<T> : IGenericUowDAL<T> where T : class
    {
        private readonly TraversalContext _context;

        public GenericUowRepository(TraversalContext context)
        {
            _context = context;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T t)
        {
            _context.Add(t);
        }

        public void MultiUpdate(List<T> t)
        {
            _context.UpdateRange(t); //UpdateRange burada bir obje istiyor, birden fazla güncelleme için bunu kullanabiliyoruz.
        }

        public void Update(T t)
        {
            _context.Update(t);
        }
    }
}
