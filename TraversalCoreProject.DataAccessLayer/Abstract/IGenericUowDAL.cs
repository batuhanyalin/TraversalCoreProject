using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DataAccessLayer.Abstract
{
    public interface IGenericUowDAL<T> where T : class
    {
        void Insert(T t);
        void Update(T t);
        void MultiUpdate(List<T> t); // MultiUpdate aynı anda birden fazla kaydı güncellemeyi sağlıyor
       T GetById(int id);
    }
}
