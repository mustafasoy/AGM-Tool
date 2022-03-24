using ArGeTesvikTool.Entities.Concrete.Mail;
using System.Threading.Tasks;

namespace ArGeTesvikTool.Business.Abstract
{
    public interface IMailService
    {
        Task SendMailAsync(MailMessage message);
    }
}
