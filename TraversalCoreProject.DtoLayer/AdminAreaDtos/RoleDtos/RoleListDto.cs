using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.AdminAreaDtos.RoleDtos
{
    public class RoleListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserCount { get; set; }
    }
}
