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
    public class WeeklyMailService
    {
        public string Onderwerp { get; set; }
        public const string Van = "bitbybit.noreply@gmail.com";
        public string Body { get; set; }

        public WeeklyMailService()
        {
            Body = GetBody();
        }

        private string GetBody()
        {
            string body = "";
            body = "<h2>" + "" + "</h2>";
            return body;
        }

        public void SendMail()
        {
            GebruikerManager GebruikerMng = new GebruikerManager();
            List<Gebruiker> gebruikers = GebruikerMng.GetGebruikers().ToList();
            foreach(Gebruiker gebruiker in gebruikers)
            {
                string Aan = gebruiker.Email;
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
}
