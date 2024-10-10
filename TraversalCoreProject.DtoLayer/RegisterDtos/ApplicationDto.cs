﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DtoLayer.RegisterDtos
{
    public class ApplicationDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string About { get; set; }
        public string Profession { get; set; }
        public string HomeTown { get; set; }
        public string MainLanguage { get; set; }
        public string? OtherLanguage { get; set; }
        public DateTime ApplicationDate { get; set; }
        public DateTime Birtday { get; set; }
        public bool IsActive { get; set; }

    }
}