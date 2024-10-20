using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.Abstract
{
    public interface ISocialMediaService:IGenericService<SocialMedia>
    {
        public SocialMedia TIsApprovedBySocialMediaId(int id);
    }
}
