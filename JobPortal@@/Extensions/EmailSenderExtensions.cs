using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using JobPortal__.Services;

namespace JobPortal__.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Welcome To Job Portal",
                $"You have successfully created an account , kindly login by <a href='{HtmlEncoder.Default.Encode(link)}'>clicking here</a>.");
        }

        public static Task SendResetPasswordAsync(this IEmailSender emailSender, string email, string callbackUrl)
        {
            return emailSender.SendEmailAsync(email, "Reset Password",
                $"Please reset your password by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
        }
    }
}
