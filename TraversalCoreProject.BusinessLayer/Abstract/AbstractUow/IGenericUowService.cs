using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.BusinessLayer.Abstract.AbstractUow
{
    public interface IGenericUowService<T> where T : class
    {
        void TInsert(T t);
        void TUpdate(T t);
        void TMultiUpdate(List<T> t); // MultiUpdate aynı anda birden fazla kaydı güncellemeyi sağlıyor
        T TGetById(int id);
    }
}
