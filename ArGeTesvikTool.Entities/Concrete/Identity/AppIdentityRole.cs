using Microsoft.AspNetCore.Identity;

namespace ArGeTesvikTool.WebUI.Models
{

    public class AppIdentityRole : IdentityRole
    {
        public string RoleText { get; set; }
    }
}
