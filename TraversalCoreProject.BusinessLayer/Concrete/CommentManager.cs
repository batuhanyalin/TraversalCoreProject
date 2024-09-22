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
    public class CommentManager : ICommentService
    {
        private readonly ICommentDAL _commentDAL;

        public CommentManager(ICommentDAL commentDAL)
        {
            _commentDAL = commentDAL;
        }

        public void TDelete(int id)
        {
            _commentDAL.Delete(id);
        }

        public Comment TGetById(int id)
        {
            return _commentDAL.GetById(id);
        }

        public List<Comment> TGetListAll()
        {
            return _commentDAL.GetListAll();
        }

        public List<Comment> TGetListAllWithAllInfoByDestinationId(int id)
        {
           return _commentDAL.GetListAllWithAllInfoByDestinationId(id);
        }

        public List<Comment> TGetListCommentWithAllInfo()
        {
            return _commentDAL.GetListCommentWithAllInfo();
        }

        public List<Comment> TGetListCommentWithAllInfoByMemberId(int id)
        {
            return _commentDAL.GetListCommentWithAllInfoByMemberId(id);
        }

        public void TInsert(Comment entity)
        {
           _commentDAL.Insert(entity);
        }

        public Comment TIsApprovedByCommentId(int id)
        {
            return _commentDAL.IsApprovedByCommentId(id);
        }

        public void TUpdate(Comment entity)
        {
            _commentDAL.Update(entity);
        }
    }
}
