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
    public class TagManager : ITagService
    {
        private readonly ITagDAL _tagDAL;

        public TagManager(ITagDAL tagDAL)
        {
            _tagDAL = tagDAL;
        }

        public void TDelete(int id)
        {
            _tagDAL.Delete(id);
        }

        public Tag TGetById(int id)
        {
           return _tagDAL.GetById(id);
        }

        public List<Tag> TGetListAll()
        {
            return _tagDAL.GetListAll();
        }

        public void TInsert(Tag entity)
        {
            _tagDAL.Insert(entity);   
        }

        public void TUpdate(Tag entity)
        {
            _tagDAL.Update(entity);
        }
    }
}
