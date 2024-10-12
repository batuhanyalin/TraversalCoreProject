namespace TraversalCoreProject.Areas.Admin.Models
{
    public class RoleAssignViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; } //Bu rol bu kullanıcıda var mı diye kontrol sağlayacak
    }
}
