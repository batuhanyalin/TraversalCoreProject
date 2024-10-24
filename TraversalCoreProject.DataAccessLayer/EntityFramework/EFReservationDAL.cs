using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.DataAccessLayer.Repositories;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DataAccessLayer.EntityFramework
{
    public class EFReservationDAL : GenericRepository<Reservation>, IReservationDAL
    {
        TraversalContext context = new TraversalContext();
        public List<Reservation> GetMyOldReservationListByUserId(int id)
        {
            var values= context.Reservations.Where(x=>x.MemberId==id).Where(x=>x.ReservationStatus.ReservationStatusName=="Geçmiş Rezervasyon" || x.Destination.StartDate < DateTime.Now).Include(x=>x.Destination).Include(x => x.Destination.City).ThenInclude(x => x.Country).ThenInclude(x => x.Continent).Include(x=>x.Member).Include(x=>x.ReservationStatus).ToList();
            return values;  
           
        }
        public List<Reservation> GetMyApprovalReservationListByUserId(int id)
        {
            var values = context.Reservations.Where(x => x.MemberId == id).Where(x => x.ReservationStatus.ReservationStatusName == "Onay Bekliyor" ).Include(x => x.Destination).Include(x => x.Destination.City).ThenInclude(x => x.Country).ThenInclude(x => x.Continent).Include(x => x.Member).Include(x => x.ReservationStatus).ToList();
            return values;

        }
        public List<Reservation> GetMyCurrentReservationListByUserId(int id)
        {
            var values = context.Reservations.Where(x => x.MemberId == id).Where(x => x.ReservationStatus.ReservationStatusName == "Onaylandı").Include(x => x.Destination).Include(x => x.Member).Include(x => x.ReservationStatus).ToList();
            return values;

        }
        public List<Reservation> GetListReservationWithAllInfo()
        {
            var values = context.Reservations.Include(x => x.Destination).Include(x => x.Member).Include(x => x.ReservationStatus).Include(x=>x.Destination.City).ThenInclude(x=>x.Country).ThenInclude(x=>x.Continent).ToList();
            return values;
        }
        public List<Reservation> GetListReservationWithAllInfoByMemberId(int id)
        {
            var values = context.Reservations.Where(x=>x.MemberId==id).Include(x => x.Destination).Include(x => x.Destination.City).ThenInclude(x => x.Country).ThenInclude(x => x.Continent).Include(x => x.Member).Include(x => x.ReservationStatus).ToList();
            return values;
        }
        public Reservation GetReservationWithAllInfoById(int id)
        {
            var values = context.Reservations.Where(x => x.ReservationId == id).Include(x => x.Destination).Include(x => x.Destination.City).ThenInclude(x => x.Country).ThenInclude(x => x.Continent).Include(x => x.Member).Include(x => x.ReservationStatus).FirstOrDefault();
            return values;
        }
    }
}
