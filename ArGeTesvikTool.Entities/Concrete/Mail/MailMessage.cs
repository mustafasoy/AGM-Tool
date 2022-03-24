using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace ArGeTesvikTool.Entities.Concrete.Mail
{
    public class MailMessage
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public MailMessage(IEnumerable<string> to, string subject, string body)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x, x)));

            Subject = subject;
            Body = body;
        }
    }
}
