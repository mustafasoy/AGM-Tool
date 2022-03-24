namespace ArGeTesvikTool.Entities.Concrete
{
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
