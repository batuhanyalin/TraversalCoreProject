using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Context;

namespace TraversalCoreProject.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDAL<T> where T : class 
    {
        TraversalContext context = new TraversalContext();
        public void Delete(int id)
        {
            var value = context.Set<T>().Find(id);
            context.Set<T>().Remove(value);
            context.SaveChanges();
        }

        public T GetById(int id)
        {
          return context.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
           return context.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }
    }
}
