﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DtoLayer.MemberAreaDtos.ReservationDtos
{
    public class AdminNewReservationDto
    {
        public AppUser Member { get; set; }
        public int MemberId { get; set; }
        public int PersonCount { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string? validationCode { get; set; }

    }
}
