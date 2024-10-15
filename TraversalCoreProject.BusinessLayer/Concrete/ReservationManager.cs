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
    public class ReservationManager : IReservationService
    {
        private readonly IReservationDAL _reservationDAL;

        public ReservationManager(IReservationDAL reservationDAL)
        {
            _reservationDAL = reservationDAL;
        }

        public void TDelete(int id)
        {
           _reservationDAL.Delete(id);
        }

        public Reservation TGetById(int id)
        {
            return _reservationDAL.GetById(id); 
        }

        public List<Reservation> TGetListAll()
        {
            return _reservationDAL.GetListAll();
        }

        public List<Reservation> TGetListReservationWithAllInfo()
        {
           return _reservationDAL.GetListReservationWithAllInfo();
        }

        public List<Reservation> TGetListReservationWithAllInfoByMemberId(int id)
        {
            return _reservationDAL.GetListReservationWithAllInfoByMemberId(id);
        }

        public List<Reservation> TGetMyApprovalReservationListByUserId(int id)
        {
            return _reservationDAL.GetMyApprovalReservationListByUserId(id);
        }

        public List<Reservation> TGetMyCurrentReservationListByUserId(int id)
        {
            return _reservationDAL.GetMyCurrentReservationListByUserId(id);
        }

        public List<Reservation> TGetMyOldReservationListByUserId(int id)
        {
           return _reservationDAL.GetMyOldReservationListByUserId(id);
        }

        public Reservation TGetReservationWithAllInfoById(int id)
        {
            return _reservationDAL.GetReservationWithAllInfoById(id);
        }

        public void TInsert(Reservation entity)
        {
            _reservationDAL.Insert(entity);
        }

        public void TMultiUpdate(List<Reservation> t)
        {
            _reservationDAL.MultiUpdate(t);
        }

        public void TUpdate(Reservation entity)
        {
            _reservationDAL.Update(entity); 
        }
    }
}
