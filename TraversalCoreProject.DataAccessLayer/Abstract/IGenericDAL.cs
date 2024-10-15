using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DataAccessLayer.Abstract
{
    public interface IGenericDAL<T> where T : class
    {  
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        T GetById(int id);
        List<T> GetListAll();
        void MultiUpdate(List<T> t);
        //List<T> GetListByFilter(Expression<Func<T, bool>> filter);
    }
}
