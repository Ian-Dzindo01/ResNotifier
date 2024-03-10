using System.Net;  
using System.Net.Mail;  

namespace SendMail {  
    class Program {
        static GameData gameData = Scraper.Start();  
        static string smtpAddress = "smtp.gmail.com";  
        static int portNumber = 587;  
        static bool enableSSL = true;  
        static string emailFromAddress = "ian.dzindo01@gmail.com";
        static string password = "umuv xmvc ovlt iyej";
        static string emailToAddress = "ian.dzindo01@gmail.com";
        static string body = "Hello, This is Email sending test using gmail.";  

        static void Main(string[] args) {
            Scraper.Start();  
            string title = gameData.Title;

            SendEmail(title, body);  
        }  
        
        public static void SendEmail(string subject, string body) {  
            using(MailMessage mail = new MailMessage()) {  
                mail.From = new MailAddress(emailFromAddress);  
                mail.To.Add(emailToAddress);  
                mail.Subject = subject;  
                mail.Body = body;  
                mail.IsBodyHtml = true;  
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));
                using(SmtpClient smtp = new SmtpClient(smtpAddress, portNumber)) {
                    smtp.UseDefaultCredentials = false;  
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);  
                    smtp.EnableSsl = enableSSL;  
                    smtp.Send(mail);  
                }  
            }  
        }

        // public static string formatString(GameData gameData)
        // {

        // }  
    }  
} 