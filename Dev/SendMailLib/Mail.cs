using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace SendMailLib
{
    class Mail
    {
        public string send(string gmailid, string password, string toemail, string subject, string body)
        {
            string msg = null;
            MailMessage mail = new MailMessage();
            mail.To.Add(toemail);
            mail.From = new MailAddress(gmailid);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            Attachment attachment;
            attachment = new Attachment("C:/Users/guill/Desktop/Crypt.pdf");
            mail.Attachments.Add(attachment);
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential
                        (gmailid, password);
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(mail);
                msg = "Your Message has been sent!";
                Console.WriteLine("!!!!!!!!!!!!!!!!!!Mail envoyé !!!!!!!!!!!!!!!!!!!");
            }
            catch (Exception)
            {
                msg = "Your Message could NOT be sent.";
                Console.WriteLine("============= Impossible d'envoyer le mail ==============");
            }
            return msg;
        }
    }
}
