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
    public class DestinationManager : IDestinationService
    {
        private readonly IDestinationDAL _destinationDAL;

        public DestinationManager(IDestinationDAL destinationDAL)
        {
            _destinationDAL = destinationDAL;
        }

        public void TDelete(int id)
        {
            _destinationDAL.Delete(id);
        }

        public List<Destination> TGetAllDestinationByApproved()
        {
            return _destinationDAL.GetAllDestinationByApproved();
        }

        public List<DestinationTag> TGetAllDestinationByTagId(int id)
        {
           return _destinationDAL.GetAllDestinationByTagId(id);
        }

        public List<Destination> TGetAllDestinationWithAllInfo()
        {
           return _destinationDAL.GetAllDestinationWithAllInfo();
        }

        public Destination TGetById(int id)
        {
            return _destinationDAL.GetById(id);
        }

        public List<Destination> TGetFeaturePosts()
        {
            return _destinationDAL.GetFeaturePosts();
        }

        public List<Destination> TGetListAll()
        {
            return _destinationDAL.GetListAll();
        }

        public void TInsert(Destination entity)
        {
            _destinationDAL.Insert(entity);
        }

        public Destination TIsApprovedByDestinationId(int id)
        {
            return _destinationDAL.IsApprovedByDestinationId(id);
        }

        public void TMultiUpdate(List<Destination> t)
        {
            _destinationDAL.MultiUpdate(t); 
        }

        public void TUpdate(Destination entity)
        {
            _destinationDAL.Update(entity);
        }
    }
}
