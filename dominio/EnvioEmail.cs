using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient("smtp.gmail.com", 587);
            server.Credentials = new NetworkCredential("pdgjestudiosprogramacion@gmail.com", "ytcugmpzueyrxtzj");
            server.EnableSsl = true;
            //server.Port = 587;
            //server.Host = "smtp.gmail.com";
        }

        public void ArmarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("norespondertpfinalequipo8@ecommerce.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;

        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

  
}
