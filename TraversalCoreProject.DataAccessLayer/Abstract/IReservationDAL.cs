using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DataAccessLayer.Abstract
{
    public interface IReservationDAL:IGenericDAL<Reservation>
    {
        public List<Reservation> GetMyOldReservationListByUserId(int id);
        public List<Reservation> GetMyApprovalReservationListByUserId(int id);
        public List<Reservation> GetMyCurrentReservationListByUserId(int id);
        public List<Reservation> GetListReservationWithAllInfo();
        public List<Reservation> GetListReservationWithAllInfoByMemberId(int id);
        public Reservation GetReservationWithAllInfoById(int id);
    }
}
