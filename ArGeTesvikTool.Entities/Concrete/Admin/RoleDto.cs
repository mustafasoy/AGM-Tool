using System.ComponentModel.DataAnnotations;

namespace ArGeTesvikTool.Entities.Concrete
{
    public class RoleDto 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public RoleName RoleName { get; set; }
        public string RoleText { get; set; }
    }

    public enum RoleName
    {
        Yönetici = 1,
        Personel = 2,
    }
}
