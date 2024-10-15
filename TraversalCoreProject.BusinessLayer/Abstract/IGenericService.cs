using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DataAccessLayer.Repositories;

namespace TraversalCoreProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TInsert(T entity);
        void TUpdate(T entity);
        void TDelete(int id);
        T TGetById(int id);
        List<T> TGetListAll();
        void TMultiUpdate(List<T> t);
        //List<T> TGetListByFilter(Expression<Func<T, bool>> filter); //Filtreyle listeleme işlemi yapacak.
    }
}
