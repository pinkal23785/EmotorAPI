using EMS.Application.DTO.Emails;
using EMS.Application.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MailKit;
//using System.Net.Mail;
using MimeKit;
using MailKit.Net.Smtp;
using MimeKit.Text;

namespace EMS.Infrastructure.Shared.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmail(EmailRequest request)
        {
            try
            {
                //SmtpClient client = new SmtpClient("smtpout.secureserver.net")
                //{
                //    Port = 465,
                //    Credentials = new NetworkCredential("feedback@emotorservice.com", "Ilovemyjob@#1590"),
                //    //EnableSsl = true,
                //};

                var message = new MimeMessage();
                //MailAddress from = new MailAddress(request.EmailFrom, request.Name, System.Text.Encoding.UTF8);
                message.From.Add(MailboxAddress.Parse(request.EmailFrom));
                message.To.Add(MailboxAddress.Parse("business@arbelosgroup.com"));
               message.To.Add(MailboxAddress.Parse("support@arbelosgroup.com"));
                message.To.Add(MailboxAddress.Parse("p.suryavanshi@arbelosgroup.com"));
                message.To.Add(MailboxAddress.Parse("pinkal.patel@arbelosgroup.com"));
                message.Subject = request.Subject;
                message.Body = new TextPart(TextFormat.Text) { Text = request.Body };
                //message.IsBodyHtml = true;

                using (var smtpClient = new SmtpClient())
                {
                    smtpClient.Connect("smtpout.secureserver.net", 465, true);
                    smtpClient.Authenticate("support@arbelosgroup.com", "Ilovemyjob@#1590");
                    smtpClient.Send(message);
                    smtpClient.Disconnect(true);
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
