using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.DataAccessLayer.Abstract;
using TraversalCoreProject.DataAccessLayer.Context;
using TraversalCoreProject.DataAccessLayer.Repositories;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DataAccessLayer.EntityFramework
{
    public class EFCommentDAL : GenericRepository<Comment>, ICommentDAL
    {
        TraversalContext context= new TraversalContext();
        public List<Comment> GetListAllWithAllInfoByDestinationId(int id)
        {
            var values = context.Comments.Where(x => x.DestinationId == id&&x.IsApproved==true).Include(x => x.Member).Include(x => x.Destination).Include(x => x.Destination.City).ThenInclude(x => x.Country).ThenInclude(x => x.Continent).ToList();
            return values;
        }
        public List<Comment> GetListCommentWithAllInfo()
        {
            var values= context.Comments.Include(x=>x.Member).Include(x=>x.Destination).Include(x => x.Destination.City).ThenInclude(x => x.Country).ThenInclude(x => x.Continent).ToList();  
            return values;
        }
        public List<Comment> GetListCommentWithAllInfoByMemberId(int id)
        {
            var values = context.Comments.Where(x=>x.MemberId==id).Include(x => x.Member).Include(x => x.Destination).Include(x=>x.Destination.City).ThenInclude(x=>x.Country).ThenInclude(x=>x.Continent).ToList();
            return values;
        }
        public Comment GetCommenById(int id)
        {
            var value = context.Comments.Where(x => x.CommentId == id).Include(x => x.Member).Include(x => x.Destination).Include(x => x.Destination.City).ThenInclude(x => x.Country).ThenInclude(x => x.Continent).FirstOrDefault();
            return value;
        }
        public Comment IsApprovedByCommentId(int id)
        {
            var value = context.Comments.Where(x => x.CommentId == id).Include(x => x.Destination.City).ThenInclude(x => x.Country).ThenInclude(x => x.Continent).FirstOrDefault();
            if (value.IsApproved == false)
            {
                value.IsApproved = true;
            }
            else
            {
                value.IsApproved = false;
            }
            context.SaveChanges();
            return value;
        }
    }
}
