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
    public class CountryManager : ICountryService
    {
        private readonly ICountryDAL _CountryDAL;

        public CountryManager(ICountryDAL CountryDAL)
        {
            _CountryDAL = CountryDAL;
        }

        public void TDelete(int id)
        {
            _CountryDAL.Delete(id);
        }

        public Country TGetById(int id)
        {
            return _CountryDAL.GetById(id);   
        }

        public List<Country> TGetListAll()
        {
           return _CountryDAL.GetListAll();
        }

        public void TInsert(Country entity)
        {
            _CountryDAL.Insert(entity);
        }

        public void TMultiUpdate(List<Country> t)
        {
            _CountryDAL.MultiUpdate(t);
        }

        public void TUpdate(Country entity)
        {
            _CountryDAL.Update(entity);
        }
    }
}
