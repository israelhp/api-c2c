using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Configuration;

namespace api_c2c.Utilities
{
    public class SendMail
    {
        public static bool Send(string addressee, string subject, string body, string title)
        {
            string email = ConfigurationManager.AppSettings["email"];
            string password = ConfigurationManager.AppSettings["passwordEmail"];
            string hostEmail = ConfigurationManager.AppSettings["hostEmail"];
            string portEmail = ConfigurationManager.AppSettings["portEmail"];

            try
            {
                MailMessage mailMessage = new MailMessage();

                mailMessage.To.Add(addressee);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = false;
                mailMessage.From = new MailAddress(email, title);
                
                SmtpClient cliente = new SmtpClient();
                cliente.UseDefaultCredentials = false;
                cliente.Credentials = new NetworkCredential(email, password);
                cliente.Port =int.Parse(portEmail);
                cliente.EnableSsl = true;
                cliente.Host = hostEmail;
                cliente.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}