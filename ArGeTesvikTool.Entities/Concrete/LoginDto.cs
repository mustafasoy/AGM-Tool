using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.WebUI.Models.Authentication
{
    public class LoginDto : IEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
