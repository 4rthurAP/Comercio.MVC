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
        public void EmailFuncionarioHandler(string to)
        {
            MailMessage message = new MailMessage("enviaremailarthur@gmail.com", to);
            message.Subject = "Tarefa pra fazer";
            message.Body = $"Voce Recebeu uma Tarefa as {DateTime.Now}.";

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("enviaremailarthur@gmail.com", "@@Send@@12"),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };  
            
            try
            {
                client.SendMailAsync(message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void EmailManagerHandler(string to, string nome)
        {
            
            var mailAddress = new MailAddress(to);
            MailMessage message = new MailMessage("enviaremailarthur@gmail.com", to);
            message.Subject = "Tarefa feita";
            message.Body = $"O funcionario {nome} terminou a tarefa as {DateTime.Now}.";

            SmtpClient client = new SmtpClient("smtp.gmail.com")
            {
                Credentials = new NetworkCredential("enviaremailarthur@gmail.com", "@@Send@@12"),
                EnableSsl = true
            };

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
