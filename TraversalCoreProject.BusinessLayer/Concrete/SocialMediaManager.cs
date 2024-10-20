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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDAL _socialMediaDAL;

        public SocialMediaManager(ISocialMediaDAL socialMediaDAL)
        {
            _socialMediaDAL = socialMediaDAL;
        }

        public void TDelete(int id)
        {
           _socialMediaDAL.Delete(id);
        }

        public SocialMedia TGetById(int id)
        {
            return _socialMediaDAL.GetById(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _socialMediaDAL.GetListAll();
        }

        public void TInsert(SocialMedia entity)
        {
            _socialMediaDAL.Insert(entity);
        }

        public SocialMedia TIsApprovedBySocialMediaId(int id)
        {
           return _socialMediaDAL.IsApprovedBySocialMediaId(id);
        }

        public void TMultiUpdate(List<SocialMedia> t)
        {
            _socialMediaDAL.MultiUpdate(t);
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialMediaDAL.Update(entity);
        }
    }
}
