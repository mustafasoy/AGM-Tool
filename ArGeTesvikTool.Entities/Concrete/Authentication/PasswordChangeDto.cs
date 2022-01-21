using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Entities.Concrete
{
    public class PasswordChangeDto : IEntity
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
