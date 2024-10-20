using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DataAccessLayer.Abstract
{
    public interface ICommentDAL:IGenericDAL<Comment>
    {
        public List<Comment> GetListAllWithAllInfoByDestinationId(int id);
        public List<Comment> GetListCommentWithAllInfo();
        public List<Comment> GetListCommentWithAllInfoByMemberId(int id);
        public Comment GetCommenById(int id);
        public Comment IsApprovedByCommentId(int id);
    }
}
