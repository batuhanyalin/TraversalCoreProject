using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.Abstract
{
    public interface IIndexBannerService:IGenericService<IndexBanner>
    {
        public IndexBanner TIsApprovedByIndexBannerId(int id);
    }
}
