using System;
using System.Net;
using System.Net.Mail;


namespace MailingService
{
    public class EmailSender : IEmailSender
    {

        private readonly string _gmailMail = "ridewithmesender@gmail.com";
        private readonly string _gmailPass = "phsy lgff mxfp qqon";



        public EmailSender()
        {
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(_gmailMail, _gmailPass)
            };

            return client.SendMailAsync(
                new MailMessage(from: _gmailMail, to: email, subject, message)
                { 
                    IsBodyHtml = true,
                    BodyEncoding = System.Text.Encoding.UTF8,
                });

        }
    }
}