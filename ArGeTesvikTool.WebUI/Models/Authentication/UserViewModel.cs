using ArGeTesvikTool.Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ArGeTesvikTool.WebUI.Models
{
    public class UserViewModel
    {
        public UserDto User { get; set; }
        public List<SelectListItem> Roles { get; set; }
    }
}