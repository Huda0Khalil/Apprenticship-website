using System.Net;
using System.Net.Mail;
using System.Text;

namespace Apprenticeship2.Helper
{
    public static class SendEmail
    {
       public static void newEmail(string to, string mailbody, string subject)
        {
            //string to = "toaddress@gmail.com"; //To address    
            string from = "fromaddress@gmail.com"; //From address    
            MailMessage message = new MailMessage(from, to);

           // string mailbody = "In this article you will learn how to send a email using Asp.Net & C#";
            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 25); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential("hudadasher@gmail.com", "h2000khalil");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
           // client.Credentials = basicCredential1;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new NetworkCredential("hudadasher@gmail.com", "h2000khalil");

            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
