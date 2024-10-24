﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.MemberAreaDtos.AnnouncementDtos
{
    public class MemberAnnouncementListDto
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Icon { get; set; }
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
    }
}