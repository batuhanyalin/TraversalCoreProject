﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DataAccessLayer.Abstract
{
    public interface ISocialMediaDAL : IGenericDAL<SocialMedia>
    {
        public SocialMedia IsApprovedBySocialMediaId(int id);
    }
}
