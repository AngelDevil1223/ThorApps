using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ThorApps.Services
{
    public static class EmailSender
    {
        public static bool EnableSsl { get; set; }
        public static int Port { get; set; }
        public static string Host { get; set; }
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static string Sender { get; set; }

        public static Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient()
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = EnableSsl,
                Port = Port,
                Host = Host,
                Credentials = new NetworkCredential()
                {
                    UserName = UserName,
                    Password = Password
                }
            };
            return Task.Run(() =>
            {
                try
                {
                    MailMessage m = new MailMessage()
                    {
                        Body = message,
                        Subject = subject,
                        From = new MailAddress(Sender),
                        IsBodyHtml = true
                    };
                    m.To.Add(email);

                    client.Send(m);
                }
                catch (Exception ex)
                {

                }
            });
        }

        public static void Configure(Dictionary<string, string> settings)
        {
            EnableSsl = settings["EnableSsl"].ToUpper() == "TRUE";
            Port = Convert.ToInt32(settings["Port"]);
            Host = settings["Host"];
            UserName = settings["UserName"];
            Password = settings["Password"];
            Sender = settings["Sender"];
        }
    }
}
