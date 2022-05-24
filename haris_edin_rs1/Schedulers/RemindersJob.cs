using MailKit.Net.Smtp;
using MimeKit;
using Quartz;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Faisal.Schedulers
{
    public class RemindersJob : IJob
    {
       
        public Task Execute(IJobExecutionContext context)
        {
            Logs($"{DateTime.Now} [Reminders Service called]" + Environment.NewLine);

            return Task.CompletedTask;
        }
        public void Logs(string message)
        {
           
                DateTime datum = DateTime.Now;

                var poruka = new MimeMessage();
                poruka.From.Add(new MailboxAddress("Xloxlo Kompanija", "xloxlohe@gmail.com"));
                poruka.To.Add(new MailboxAddress("edub", "gondzo.edin@gmail.com"));
                poruka.Subject = "Obavjestenje o registraciji";
                poruka.Body = new TextPart("plain")
                {
                    Text = "Potrebno staviti slanje funkcionalnih stvari na mail. NPR broj korisnika kroz vrijeme, broj artikala isl"
                };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("xloxlohe@gmail.com", "Hehehehe");
                    client.Send(poruka);
                    client.Disconnect(true);
                }
       
        }
    }
}