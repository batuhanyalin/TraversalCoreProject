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
    public class AnnouncementManager : IAnnouncementService
    {
        private readonly IAnnouncementDAL _announcementDAL;

        public AnnouncementManager(IAnnouncementDAL announcementDAL)
        {
            _announcementDAL = announcementDAL;
        }

        public void TDelete(int id)
        {
            _announcementDAL.Delete(id);
        }

        public Announcement TGetById(int id)
        {
            return _announcementDAL.GetById(id);
        }

        public List<Announcement> TGetListAll()
        {
            return _announcementDAL.GetListAll();
        }

        public void TInsert(Announcement entity)
        {
            _announcementDAL.Insert(entity);
        }

        public void TMultiUpdate(List<Announcement> t)
        {
            _announcementDAL.MultiUpdate(t);
        }

        public void TUpdate(Announcement entity)
        {
            _announcementDAL.Update(entity);
        }
    }
}
