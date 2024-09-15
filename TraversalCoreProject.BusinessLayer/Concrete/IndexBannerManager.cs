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
    public class IndexBannerManager : IIndexBannerService
    {
        private readonly IIndexBannerDAL _indexBannerDAL;

        public IndexBannerManager(IIndexBannerDAL indexBannerDAL)
        {
            _indexBannerDAL = indexBannerDAL;
        }

        public void TDelete(int id)
        {
           _indexBannerDAL.Delete(id);
        }

        public IndexBanner TGetById(int id)
        {
           return _indexBannerDAL.GetById(id);  
        }

        public List<IndexBanner> TGetListAll()
        {
            return _indexBannerDAL.GetListAll();
        }

        public void TInsert(IndexBanner entity)
        {
            _indexBannerDAL.Insert(entity);
        }

        public void TUpdate(IndexBanner entity)
        {
            _indexBannerDAL.Update(entity);
        }
    }
}
