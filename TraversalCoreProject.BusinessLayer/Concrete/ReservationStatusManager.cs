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
    public class ReservationStatusManager : IReservationStatusService
    {
        private readonly IReservationStatusDAL _reservationStatusDAL;

        public ReservationStatusManager(IReservationStatusDAL reservationStatusDAL)
        {
            _reservationStatusDAL = reservationStatusDAL;
        }

        public void TDelete(int id)
        {
           _reservationStatusDAL.Delete(id);
        }

        public ReservationStatus TGetById(int id)
        {
            return _reservationStatusDAL.GetById(id);
        }

        public List<ReservationStatus> TGetListAll()
        {
            return _reservationStatusDAL.GetListAll();
        }

        public void TInsert(ReservationStatus entity)
        {
            _reservationStatusDAL.Insert(entity);
        }

        public void TMultiUpdate(List<ReservationStatus> t)
        {
            _reservationStatusDAL.MultiUpdate(t);
        }

        public void TUpdate(ReservationStatus entity)
        {
            _reservationStatusDAL.Update(entity);
        }
    }
}
