using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.EntityLayer.Concrete;

namespace TraversalCoreProject.DtoLayer.RegisterDtos
{
    public class RegisterDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Profession { get; set; }
        public DateTime Birtday { get; set; }
        public bool IsActive { get; set; }
        public List<DestinationMatchGuide> DestinationMatchGuides { get; set; }
    }
}
