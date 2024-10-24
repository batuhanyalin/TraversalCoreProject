using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.Concrete
{
    public class ContinentManager : IContinentService
    {
        private readonly IContinentDAL _ContinentDAL;

        public ContinentManager(IContinentDAL ContinentDAL)
        {
            _ContinentDAL = ContinentDAL;
        }

        public void TDelete(int id)
        {
            _ContinentDAL.Delete(id);
        }

        public Continent TGetById(int id)
        {
            return _ContinentDAL.GetById(id);   
        }

        public List<Continent> TGetListAll()
        {
           return _ContinentDAL.GetListAll();
        }

        public void TInsert(Continent entity)
        {
            _ContinentDAL.Insert(entity);
        }

        public void TMultiUpdate(List<Continent> t)
        {
            _ContinentDAL.MultiUpdate(t);
        }

        public void TUpdate(Continent entity)
        {
            _ContinentDAL.Update(entity);
        }
    }
}
