using ArGeTesvikTool.Entities.Concrete;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models
{
    public class UserViewModel
    {
        public UserDto User { get; set; }
        public string RoleName { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}