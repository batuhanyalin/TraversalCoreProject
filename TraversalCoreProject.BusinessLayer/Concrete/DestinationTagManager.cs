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
    public class DestinationTagManager : IDestinationTagService
    {
        private readonly IDestinationTagDAL _destinationTagDAL;

        public DestinationTagManager(IDestinationTagDAL destinationTagDAL)
        {
            _destinationTagDAL = destinationTagDAL;
        }

        public void TDelete(int id)
        {
            _destinationTagDAL.Delete(id);
        }

        public DestinationTag TGetById(int id)
        {
            return _destinationTagDAL.GetById(id);
        }

        public List<DestinationTag> TGetListAll()
        {
            return _destinationTagDAL.GetListAll();
        }

        public List<DestinationTag> TGetTagsAllByDestinationId(int id)
        {
           return _destinationTagDAL.GetTagsAllByDestinationId(id);
        }

        public void TInsert(DestinationTag entity)
        {
            _destinationTagDAL.Insert(entity);
        }

        public void TMultiUpdate(List<DestinationTag> t)
        {
            _destinationTagDAL.MultiUpdate(t);
        }

        public void TUpdate(DestinationTag entity)
        {
            _destinationTagDAL.Update(entity);
        }
    }
}
