using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Comercio.MVC.Services.Handlers
{
    public class EnviarEmailHandler
    {
        public EnviarEmailHandler()
        {

        }

        public void EmailHandler(string to, string from)
        {


            MailMessage message = new MailMessage(from, to);
            message.Subject = "Good morning, Elizabeth";
            message.Body = $"Voce Recebeu uma Tarefa para {DateTime.Now}";

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("smtp_username", "smtp_password"),
                EnableSsl = true
            };
            // code in brackets above needed if authentication required
            try
            {
                client.Send(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
