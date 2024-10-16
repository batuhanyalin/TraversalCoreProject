﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.BusinessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.Concrete
{
    public class DestinationMatchGuideManager : IDestinationMatchGuideService
    {
        private readonly IDestinationMatchGuideDAL _destinationMatchGuideDAL;

        public DestinationMatchGuideManager(IDestinationMatchGuideDAL destinationMatchGuideDAL)
        {
            _destinationMatchGuideDAL = destinationMatchGuideDAL;
        }

        public void TDelete(int id)
        {
           _destinationMatchGuideDAL.Delete(id);
        }

        public DestinationMatchGuide TGetById(int id)
        {
            return _destinationMatchGuideDAL.GetById(id);
        }

        public List<DestinationMatchGuide> TGetDestinationAllByGuideId(int id)
        {
          return _destinationMatchGuideDAL.GetDestinationAllByGuideId(id);
        }

        public List<DestinationMatchGuide> TGetGuideAllByDestinationId(int id)
        {
            return _destinationMatchGuideDAL.GetGuideAllByDestinationId(id);
        }

        public List<DestinationMatchGuide> TGetListAll()
        {
            return _destinationMatchGuideDAL.GetListAll();
        }

        public void TInsert(DestinationMatchGuide entity)
        {
           _destinationMatchGuideDAL.Insert(entity);
        }

        public void TMultiUpdate(List<DestinationMatchGuide> t)
        {
           _destinationMatchGuideDAL.MultiUpdate(t);
        }

        public void TUpdate(DestinationMatchGuide entity)
        {
            _destinationMatchGuideDAL.Update(entity);
        }
    }
}
