using ArGeTesvikTool.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models.Admin
{
    public class UserListViewModel
    {
        public List<UserDto> Users { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}