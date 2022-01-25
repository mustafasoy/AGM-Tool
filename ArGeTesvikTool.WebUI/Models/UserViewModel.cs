using ArGeTesvikTool.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Models
{
    public class UserViewModel
    {
        public UserDto User { get; set; }
        public string RoleName { get; set; }
        public List<RoleDto> RoleList { get; set; }
    }
}