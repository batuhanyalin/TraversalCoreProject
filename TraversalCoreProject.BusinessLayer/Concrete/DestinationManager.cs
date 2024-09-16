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

        public void TUpdate(Destination entity)
        {
            _destinationDAL.Update(entity);
        }
    }
}
