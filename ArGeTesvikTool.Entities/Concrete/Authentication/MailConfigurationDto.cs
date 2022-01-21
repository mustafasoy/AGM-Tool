using ArGeTesvikTool.Entities.Abstract;

namespace ArGeTesvikTool.Business.Concrete
{
    public class MailConfigurationDto : IEntity
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string From { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
