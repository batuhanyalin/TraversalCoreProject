using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.Abstract
{
    public interface IReservationService:IGenericService<Reservation>
    {
        public List<Reservation> TGetMyOldReservationListByUserId(int id);
        public List<Reservation> TGetMyApprovalReservationListByUserId(int id);
        public List<Reservation> TGetMyCurrentReservationListByUserId(int id);
        public List<Reservation> TGetListReservationWithAllInfo();
        public List<Reservation> TGetListReservationWithAllInfoByMemberId(int id);
        public Reservation TGetReservationWithAllInfoById(int id);
    }
}
