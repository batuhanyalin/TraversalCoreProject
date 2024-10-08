﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.BusinessLayer.Abstract
{
    public interface IDestinationMatchGuideService : IGenericService<DestinationMatchGuide>
    {
        public List<DestinationMatchGuide> TGetGuideAllByDestinationId(int id);
        public List<DestinationMatchGuide> TGetDestinationAllByGuideId(int id);
    }
}
