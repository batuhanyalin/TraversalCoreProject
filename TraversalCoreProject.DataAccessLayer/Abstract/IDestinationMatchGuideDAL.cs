using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DataAccessLayer.Abstract
{
    public interface IDestinationMatchGuideDAL : IGenericDAL<DestinationMatchGuide>
    {
        public List<DestinationMatchGuide> GetGuideAllByDestinationId(int id);
    }
}
