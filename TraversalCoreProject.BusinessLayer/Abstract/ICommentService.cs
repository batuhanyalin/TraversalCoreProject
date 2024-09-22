using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        public List<Comment> TGetListAllWithAllInfoByDestinationId(int id);
        public List<Comment> TGetListCommentWithAllInfo();
        public List<Comment> TGetListCommentWithAllInfoByMemberId(int id);
        public Comment TIsApprovedByCommentId(int id);
    }
}
