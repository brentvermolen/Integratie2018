using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BL.Domain;

namespace BL
{
    public class AlertMailService
    {
        public string Aan { get; set; }
        public string Onderwerp { get; set; }
        public const string Van = "bitbybit.noreply@gmail.com";
        public string Body { get; set; }

        public Alert Alert { get; set; }

        public AlertMailService(Alert alert)
        {
            Aan = alert.Gebruiker.Email;
            Alert = alert;
            Body = GetBody();
        }

        private string GetBody()
        {
            string body = "";
            body = "<h2>" + Alert.Persoon.Naam + "</h2>";
            return body;
        }

        public void SendMail()
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(Van, "BitByBit123"),
                EnableSsl = true
            };

            MailMessage msg = new MailMessage(new MailAddress(Van, "Bit By Bit", Encoding.UTF8), new MailAddress(Aan));
            msg.Subject = Onderwerp;
            msg.Body = Body;
            msg.IsBodyHtml = true;

            client.Send(msg);
        }
    }
}
