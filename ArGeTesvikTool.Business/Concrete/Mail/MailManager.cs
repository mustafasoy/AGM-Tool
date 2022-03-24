using ArGeTesvikTool.Business.Abstract;
using ArGeTesvikTool.Business.Concrete;
using ArGeTesvikTool.Entities.Concrete.Mail;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArGeTesvikTool.WebUI.Helpers
{
    public class MailManager : IMailService
    {
        private readonly IConfiguration _configuration;

        public MailManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(MailMessage message)
        {
            var emailConfig = _configuration.GetSection("EmailConfiguration").Get<MailConfiguration>();

            var mailConfiguration = new MailConfiguration
            {
                SmtpServer = emailConfig.SmtpServer,
                Port = emailConfig.Port,
                From = emailConfig.From,
                Username = emailConfig.Username,
                Password = emailConfig.Password, //_configuration.GetValue<string>("EmailConfiguration:Password"),
            };

            var emailMessage = CreateMail(mailConfiguration, message);

            await SendAsync(mailConfiguration, emailMessage);
        }

        private static MimeMessage CreateMail(MailConfiguration configuration, MailMessage message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(
                new MailboxAddress(
                    "Borusan AGM Portal",
                    configuration.From
                    )
                );
            emailMessage.To.AddRange(message.To);

            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart("html")
            {
                Text = message.Body
            };

            return emailMessage;
        }

        private static async Task SendAsync(MailConfiguration configuration, MimeMessage message)
        {
            using var client = new SmtpClient();
            try
            {
                await client.ConnectAsync(configuration.SmtpServer, configuration.Port, true);
                await client.AuthenticateAsync(configuration.Username, configuration.Password);

                await client.SendAsync(message);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                await client.DisconnectAsync(true);
            }
        }
    }
}
