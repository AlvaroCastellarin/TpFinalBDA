using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Rust_Eze
{
    public static class EmailHelper
    {
        public static void SendResetEmail(string toEmail, string username, string token)
        {
            if (string.IsNullOrWhiteSpace(toEmail)) throw new ArgumentException("toEmail vacío");

            string smtpHost = ConfigurationManager.AppSettings["smtpHost"];
            int smtpPort = int.TryParse(ConfigurationManager.AppSettings["smtpPort"], out int p) ? p : 25;
            bool enableSsl = bool.TryParse(ConfigurationManager.AppSettings["smtpEnableSsl"], out bool s) ? s : false;
            string smtpUser = ConfigurationManager.AppSettings["smtpUser"];
            string smtpPass = ConfigurationManager.AppSettings["smtpPass"];
            string fromAddress = ConfigurationManager.AppSettings["smtpFrom"];
            string fromDisplay = ConfigurationManager.AppSettings["smtpFromName"] ?? "Rust-Eze";

            if (string.IsNullOrWhiteSpace(smtpHost) || string.IsNullOrWhiteSpace(fromAddress))
                throw new Exception("Configure SMTP en App.config (smtpHost y smtpFrom).");


            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            var body = $"Hola {username},\n\n" +
                       "Has solicitado recuperar tu contraseña. Usa este código en la aplicación para restablecerla (válido 1 hora):\n\n" +
                       token + "\n\n" +
                       "Si no solicitaste esto, ignora este correo.\n\n" +
                       "Atte,\nRust-Eze";

            using (var msg = new MailMessage())
            {
                msg.From = new MailAddress(fromAddress, fromDisplay);
                msg.To.Add(new MailAddress(toEmail));
                msg.Subject = "Recuperación de contraseña - Rust-Eze";
                msg.Body = body;
                msg.IsBodyHtml = false;

                using (var client = new SmtpClient(smtpHost, smtpPort))
                {
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = enableSsl;
                    client.Timeout = 20000; 

                    if (!string.IsNullOrWhiteSpace(smtpUser))
                    {
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(smtpUser, smtpPass);
                    }
                    else
                    {
                        client.UseDefaultCredentials = true;
                    }

                    try
                    {
                        client.Send(msg);
                    }
                    catch (SmtpException ex)
                    {
                        throw new Exception("Error al enviar correo. " + ex.ToString());
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error al enviar correo. " + ex.ToString());
                    }
                }
            }
        }
    }
}
