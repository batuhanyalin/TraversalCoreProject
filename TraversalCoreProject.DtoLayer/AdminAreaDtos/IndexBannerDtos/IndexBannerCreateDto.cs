﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.AdminAreaDtos.IndexBannerDtos
{
    public class IndexBannerCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
    }
}