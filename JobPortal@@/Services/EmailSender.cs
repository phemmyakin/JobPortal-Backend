using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal__.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            //return Task.CompletedTask;
            return Execute(email, subject, message);
        }

        public Task Execute(string email, string subject, string message)
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGridKey");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("oakinnigbagbe@eminenttechnology.com", "Job Portal"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));
            //msg.SetClickTracking(false, false);
            return client.SendEmailAsync(msg);

        }
    }
}
