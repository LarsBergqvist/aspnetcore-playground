using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace RazorPages_Login_SendGrid.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly AuthMessageSenderSettings _settings;
        public EmailSender(IOptions<AuthMessageSenderSettings> optionsAccessor)
        {
            _settings = optionsAccessor.Value;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SendGridClient(_settings.SendGridApiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(_settings.SendGridSenderEmail, _settings.SendGridSenderName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
