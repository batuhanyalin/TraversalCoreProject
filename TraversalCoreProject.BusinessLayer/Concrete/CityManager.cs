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
    public class CityManager : ICityService
    {
        private readonly ICityDAL _CityDAL;

        public CityManager(ICityDAL CityDAL)
        {
            _CityDAL = CityDAL;
        }

        public void TDelete(int id)
        {
            _CityDAL.Delete(id);
        }

        public List<City> TGetAllCity()
        {
            return _CityDAL.GetAllCity();
        }

        public City TGetById(int id)
        {
            return _CityDAL.GetById(id);   
        }

        public List<City> TGetListAll()
        {
           return _CityDAL.GetListAll();
        }

        public void TInsert(City entity)
        {
            _CityDAL.Insert(entity);
        }

        public void TMultiUpdate(List<City> t)
        {
            _CityDAL.MultiUpdate(t);
        }

        public void TUpdate(City entity)
        {
            _CityDAL.Update(entity);
        }
    }
}
