using Microsoft.AspNetCore.Identity;

namespace ArGeTesvikTool.WebUI.Models
{
    public class AppIdentityUser : IdentityUser
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}
