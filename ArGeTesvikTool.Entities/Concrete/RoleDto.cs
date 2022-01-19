using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Entities.Concrete
{
    public class RoleDto : IEntity
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
    }
}
