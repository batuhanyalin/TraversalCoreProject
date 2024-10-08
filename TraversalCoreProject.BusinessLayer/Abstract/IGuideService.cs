﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.Abstract
{
    public interface IGuideService : IGenericService<AppUser>
    {
        public AppUser TGetGuideDetailById(int id);
        public AppUser TIsApprovedByUserId(int id);
    }
}
