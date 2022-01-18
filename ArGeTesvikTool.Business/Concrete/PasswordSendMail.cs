using ArGeTesvikTool.Business.Abstract;
using ArGeTesvikTool.Business.Concrete;
using System.Net;
using System.Net.Mail;

namespace ArGeTesvikTool.WebUI.Helpers
{
    public class PasswordSendMail : IMailService
    {
        public void CreateMail(MailConfigurationDto mailConfiguration, string link, string email)
        {
            var stmp = new SmtpClient
            {
                Host = mailConfiguration.SmtpServer,
                Port = mailConfiguration.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(mailConfiguration.UserName, mailConfiguration.Password)
            };
            string body = "<h2>Şifrenizi yenilemek için linke tıklayınız.</h2><hr/>";
            body += $"<a href='{link}'>şifre yenileme linki</a>";
            using (var message = new MailMessage(mailConfiguration.From, email)
            {
                Subject = "Test",
                Body = body,
                IsBodyHtml = true
            })
            {
                stmp.Send(message);
            }
        }

        public void SendMail()
        {
        }
    }
}
