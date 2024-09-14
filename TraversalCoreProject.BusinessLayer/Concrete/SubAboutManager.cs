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
    public class SubAboutManager : ISubAboutService
    {
        private readonly ISubAboutDAL _subAboutDAL;

        public SubAboutManager(ISubAboutDAL subAboutDAL)
        {
            _subAboutDAL = subAboutDAL;
        }

        public void TDelete(int id)
        {
            _subAboutDAL.Delete(id);
        }

        public SubAbout TGetById(int id)
        {
            return _subAboutDAL.GetById(id);
        }

        public List<SubAbout> TGetListAll()
        {
            return _subAboutDAL.GetListAll();
        }

        public void TInsert(SubAbout entity)
        {
            _subAboutDAL.Insert(entity);
        }

        public void TUpdate(SubAbout entity)
        {
            _subAboutDAL.Update(entity);
        }
    }
}
