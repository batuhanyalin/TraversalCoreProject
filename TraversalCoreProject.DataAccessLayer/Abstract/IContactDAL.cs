﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DataAccessLayer.Abstract
{
    public interface IContactDAL:IGenericDAL<Contact>
    {
        public Contact IsApprovedByContactId(int id);
    }
}
