using System.Net;
using System.Net.Mail;

namespace CRM_University.Core
{
    public class EmailSender
    {
        public static void SendEmail(string userToEmail, string message)
        {
            var senderEmail = new MailAddress("arsen1997b@mail.ru", "");
            var receiverEmail = new MailAddress($"arsen.bayramyan1997@gmail.com", "");
            var password = "********";
            var subject = "Order";
            var smtp = new SmtpClient
            {

                Host = "smtp.mail.ru",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, password)
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = message
            })
            {
                smtp.Send(mess);
            }
        }
    }
}
