using ArGeTesvikTool.Business.Concrete;

namespace ArGeTesvikTool.Business.Abstract
{
    public interface IMailService
    {
        void CreateMail(MailConfigurationDto mailConfiguration, string link, string email);
        void SendMail();
    }
}
