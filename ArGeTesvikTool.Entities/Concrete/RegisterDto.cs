using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.WebUI.Models.Authentication
{
    public class RegisterDto : IEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
