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
    public class About2Manager : IAbout2Service
    {
        private readonly IAbout2DAL _about2DAL;

        public About2Manager(IAbout2DAL about2DAL)
        {
            _about2DAL = about2DAL;
        }

        public void TDelete(int id)
        {
            _about2DAL.Delete(id);
        }

        public About2 TGetById(int id)
        {
           return _about2DAL.GetById(id);
        }

        public List<About2> TGetListAll()
        {
            return _about2DAL.GetListAll();
        }

        public void TInsert(About2 entity)
        {
            _about2DAL.Insert(entity);
        }

        public void TUpdate(About2 entity)
        {
           _about2DAL.Update(entity);
        }
    }
}
