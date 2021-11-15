using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LifeGoals.Email
{
    public class SendEmail
    {
        public Task SendAsync(string email,string message,string body,string emailSender,string SenderPassword)
        {

            MailAddress from = new MailAddress(emailSender, "LifeGoals!");
       
            MailAddress to = new MailAddress(email);
           
           
            
            MailMessage mailMessage = new MailMessage(from, to);
            mailMessage.Body = body;
            mailMessage.Subject = message;
           
            SmtpClient smtp = new SmtpClient("smtp.yandex.ru", 587);
           
            mailMessage.IsBodyHtml = true;
           
            mailMessage.Body = body;
           
            
            smtp.Credentials = new NetworkCredential(emailSender, SenderPassword);
           
            smtp.EnableSsl = true;


            return smtp.SendMailAsync(mailMessage);
        }
    }
}