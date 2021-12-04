using System;
using System.Threading.Tasks;
using HelpYourCity.Core.Contracts;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace HelpYourCity.Persistence.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SmtpClient smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync("smtp.gmail.com", 587, false).ConfigureAwait(false);
            smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
            await smtpClient.AuthenticateAsync("unihack.helpyourcity@gmail.com", "unihack2021");

            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("Help Your City", "no-reply@helpyourcity.ro"));
            mail.To.Add(new MailboxAddress(email, email));
            mail.Subject = subject;
            var body = new BodyBuilder();
            body.HtmlBody = htmlMessage;
            mail.Body = body.ToMessageBody();
            try
            {
                await smtpClient.SendAsync(mail);
            }
            catch (Exception ex)
            {
            }
        }
    }
}