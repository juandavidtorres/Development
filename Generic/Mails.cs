//Development by Kelmer Ashley Comas Cardona © 2015

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace Generic
{
    public static class Mails
    {
        public class ServerMail
        {
            public ServerMail() { }
            public ServerMail(string serverHost, string sender, string password,
                              bool isSSL = true, bool isBodyHTML = true, int port = 25)
            {
                this.ServerHost = serverHost;
                this.Port = port;
                this.SSL = isSSL;
                this.Sender = sender;
                this.PasswordSender = password;
                this.IsBodyHTML = isBodyHTML;
            }

            public int Port { get; set; }
            public string ServerHost { get; set; }
            public string Sender { get; set; }
            public string PasswordSender { get; set; }
            public bool SSL { get; set; }
            public bool IsBodyHTML { get; set; }
        }


        public static void SendMail(string sendTo, string bodyContent, string subject, ServerMail server, int timeOut = 3000)
        {
            MailMessage message = new MailMessage();

            sendTo = sendTo.Trim(';');

            string[] mails = sendTo.Split(';');



            foreach (string s in mails)
            {
                message.To.Add(s);
            }


            message.From = new MailAddress(server.Sender);

            message.Subject = subject;
            message.SubjectEncoding = Encoding.UTF8;
            message.BodyEncoding = Encoding.UTF8;
            message.Body = bodyContent;
            message.IsBodyHtml = server.IsBodyHTML;
            string file = "C:/EncabezadoNuevo.png";
            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            message.Attachments.Add(data);

            using (SmtpClient client = new SmtpClient())
            {
                client.Credentials = new NetworkCredential(server.Sender, server.PasswordSender);

                client.Port = server.Port;
                client.EnableSsl = server.SSL;
                client.Host = server.ServerHost;
                client.Timeout = timeOut;

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
}
