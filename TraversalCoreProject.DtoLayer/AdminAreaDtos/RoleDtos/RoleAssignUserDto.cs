using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.AdminAreaDtos.RoleDtos
{
    public class RoleAssignUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool RoleExist { get; set; }
    }
}
