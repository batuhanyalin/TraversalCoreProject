using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.DefaultDtos.ApplicationDtos
{
    public class ApplicationCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string About { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }
        public string? HomeTown { get; set; }
        public string? MainLanguage { get; set; }
        public string? OtherLanguage { get; set; }
        public string ImageUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public DateTime Birtday { get; set; }
        public DateTime ApplicationDate { get; set; }
        public bool IsApproved { get; set; }
    }
}
