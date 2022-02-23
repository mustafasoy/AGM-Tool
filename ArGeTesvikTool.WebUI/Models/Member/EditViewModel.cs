using ArGeTesvikTool.Entities.Concrete;

namespace ArGeTesvikTool.WebUI.Models.Member
{
    public class EditViewModel
    {
        public UserDto User { get; set; }
        public PasswordChangeDto Password { get; set; }
    }
}
