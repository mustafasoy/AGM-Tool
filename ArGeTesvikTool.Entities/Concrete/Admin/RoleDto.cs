using ArGeTesvikTool.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace ArGeTesvikTool.Entities.Concrete
{
    public class RoleDto : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RoleText { get; set; }
    }
}
