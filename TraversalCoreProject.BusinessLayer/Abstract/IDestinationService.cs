using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        public List<Destination> TGetFeaturePosts();
        public List<Destination> TGetAllDestinationWithAllInfo();
        public List<DestinationTag> TGetAllDestinationByTagId(int id);
        public Destination TIsApprovedByDestinationId(int id);
        public List<Destination> TGetAllDestinationByApproved();
        public List<Destination> TGetLastDestinationForMemberDashboard();
    }
}
