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
    public class GuideManager : IGuideService
    {
        private readonly IGuideDAL _guideDAL;

        public GuideManager(IGuideDAL guideDAL)
        {
            _guideDAL = guideDAL;
        }

        public void TDelete(int id)
        {
            _guideDAL.Delete(id);
        }

        public AppUser TGetById(int id)
        {
            return _guideDAL.GetById(id);
        }

        public AppUser TGetGuideDetailById(int id)
        {
         return _guideDAL.GetGuideDetailById(id);
        }

        public List<AppUser> TGetListAll()
        {
            return _guideDAL.GetListAll();
        }

        public void TInsert(AppUser entity)
        {
            _guideDAL.Insert(entity);
        }

        public AppUser TIsApprovedByUserId(int id)
        {
            return _guideDAL.IsApprovedByUserId(id);
        }

        public void TMultiUpdate(List<AppUser> t)
        {
            _guideDAL.MultiUpdate(t);
        }

        public void TUpdate(AppUser entity)
        {
          _guideDAL.Update(entity);
        }
    }
}
