using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace haris_edin_rs1.EmailConfig
{

    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
    }
    public class EmailService : IEmailService
    {
   
    
        public bool SendEmail(EmailData emailData)
        {
            try
            {
                DateTime datum = DateTime.Now;

                var poruka = new MimeMessage();
                poruka.From.Add(new MailboxAddress("eeee", "xloxlohe@gmail.com"));
                poruka.To.Add(new MailboxAddress(emailData.EmailToName.ToString(), emailData.EmailToId.ToString()));
                poruka.Subject = emailData.EmailSubject.ToString();
                poruka.Body = new TextPart("plain")
                {
                    Text = emailData.EmailBody.ToString()
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("xloxlohe@gmail.com", "Hehehehe");
                    client.Send(poruka);
                    client.Disconnect(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                return false;
            }
        }
    }
}
