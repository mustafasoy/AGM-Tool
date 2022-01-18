using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Entities.Concrete
{
    public class ResetPasswordDto : IEntity
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
