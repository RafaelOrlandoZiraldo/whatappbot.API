using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.aplication.Interface;
using Microsoft.Extensions.Configuration;

namespace whatappbot.aplication.Services
{
    public class EmailService: IEmailService
    {
        private readonly string _apiKey;
        private readonly string _fromEmail;
        private readonly string _fromName;

        public EmailService(IConfiguration config)
        {
            _apiKey = config["SendGrid:ApiKey"];
            _fromEmail = config["SendGrid:FromEmail"];
            _fromName = config["SendGrid:FromName"];
        }

        public async Task SendEmailAsync(string to, string subject, string body, bool isHtml = true)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress(_fromEmail, _fromName);
            var toEmail = new EmailAddress(to);

            var msg = MailHelper.CreateSingleEmail(
                from,
                toEmail,
                subject,
                isHtml ? null : body,
                isHtml ? body : null
            );

            var response = await client.SendEmailAsync(msg);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error enviando mail: {response.StatusCode}");
            }
        }
    }
}
