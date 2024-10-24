using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraversalCoreProject.DtoLayer.DefaultDtos.PasswordDtos
{
    public class ResetPasswordDto
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
