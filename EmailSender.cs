using System;
using System.Net;  
using System.Net.Mail;  
using System.Collections.Generic;

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
            var games = gameData.Games;  
            string title = gameData.Title;
            string body = formatString(games);
            SendEmail(title, body);  
        }  
        
        public static void SendEmail(string subject, string body) {  
            using(MailMessage mail = new MailMessage()) {  
                mail.From = new MailAddress(emailFromAddress);  
                mail.To.Add(emailToAddress);  
                mail.Subject = subject;  
                mail.Body = body;  
                mail.IsBodyHtml = false;  
                //mail.Attachments.Add(new Attachment("D:\\TestFile.txt"));
                using(SmtpClient smtp = new SmtpClient(smtpAddress, portNumber)) {
                    smtp.UseDefaultCredentials = false;  
                    smtp.Credentials = new NetworkCredential(emailFromAddress, password);  
                    smtp.EnableSsl = enableSSL;  
                    smtp.Send(mail);  
                }  
            }  
        }

        public static string formatString(List<Game> games)
        {
            var stringBuilder = new System.Text.StringBuilder();

            for (int i = 0; i < games.Count; i++)
                stringBuilder.AppendLine(@$"{games[i].homeTeam} {games[i].homeTeamScore}    {games[i].awayTeamScore} {games[i].awayTeam}");

            return stringBuilder.ToString();   
        }
    }  
} 