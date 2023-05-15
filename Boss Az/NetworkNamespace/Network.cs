using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Boss.ModelsNamespace;
using static Boss.Functions.Functions;

namespace Boss.NetworkNamespace {
    public static class Network {

        public static bool isHtml = false;
        public static MailAddress to;
        private static MailAddress from = new MailAddress("bossconsoleaz@gmail.com");
        private static MailMessage email;

        public static void sendMail(string mail, Notification notification) {
            try {
                to = new MailAddress(mail);
                email = new MailMessage(from, to);
            }catch(Exception ex) {
                Console.WriteLine(ex.Message);
                PressAnyKey();
            }

            email.IsBodyHtml = isHtml;
            email.Subject = notification.Title;
            email.Body = notification.Text;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 25;
            smtp.Credentials = new NetworkCredential("bossconsoleaz@gmail.com", "Your App Password");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            try {
                /* Send method called below is what will send off our email 
                    * unless an exception is thrown.
                    */
                smtp.Send(email);
                isHtml = false;
            }
            catch (SmtpException ex) {
                Console.WriteLine(ex.Message);
                PressAnyKey();
            }

        }
    }
}
