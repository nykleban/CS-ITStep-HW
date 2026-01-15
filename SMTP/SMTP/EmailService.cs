using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace SMTP
    {
        public class EmailService
        {
            private readonly string host;
            private readonly int port;
            private readonly string email;
            private readonly string password;
            private readonly SmtpClient smtpClient;

            public EmailService()
            {
                host = "smtp.gmail.com";
                port = 587;
                email = "";
                password = "";

                smtpClient = new SmtpClient(host, port);
                smtpClient.Credentials = new NetworkCredential(email, password);
                smtpClient.EnableSsl = true;
            }
            public string getEmail()
            {
                return email;
            }
            public string getPassword()
            {
                return password;
            }
            public void SendEmail(string toEmail, string subject, string bodyFilePath, string attachmentPath = null)
            {
            
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(email);
                msg.To.Add(toEmail);
                msg.Subject = subject;

                if (File.Exists(bodyFilePath))
                {
                    string bodyContent = File.ReadAllText(bodyFilePath);
                    msg.Body = bodyContent;

                    string extension = Path.GetExtension(bodyFilePath).ToLower();
                    if (extension == ".html" || extension == ".htm") msg.IsBodyHtml = true;
                    else msg.IsBodyHtml = false;
                    
                }
                else
                {
                    throw new FileNotFoundException($"Файл з текстом листа не знайдено: {bodyFilePath}");
                }

                if (!string.IsNullOrEmpty(attachmentPath))
                {
                    if (File.Exists(attachmentPath))
                    {
                        Attachment attachment = new Attachment(attachmentPath);
                        msg.Attachments.Add(attachment);
                    }
                    else
                    {
                        Console.WriteLine($"[Увага] Файл вкладення не знайдено: {attachmentPath}. Лист буде відправлено без нього.");
                    }
                }

                smtpClient.Send(msg);
            }
        }
    }
