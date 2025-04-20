using System.Net;
using System.Net.Mail;

namespace company.G03.PL.Models.Auth
{
    public static class EmailSender
    {
public static void SendEmail( ResetPasswordViewModel Email)
        {
            var claint = new SmtpClient("smtp.gmail.com", 587);
            claint.EnableSsl = true;
            claint.Credentials = new NetworkCredential("mhamedelshikh3@gmail.com" , "cfyhyrigprdenfyz");
            claint.Send("mhamedelshikh3@gmail.com", Email.To, Email.Subject, Email.Body);
        }
    }
}
