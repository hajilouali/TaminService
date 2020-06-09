//using Common;
//using MailKit.Net.Smtp;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Configuration;
//using MimeKit;
//using System;
//using System.IO;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace Services.Services.EmailService
//{
//    public class EmailSender : IEmailSender
//    {
//        private readonly EmailConfiguration _emailConfig;
//        private readonly SiteSettings _siteSetting;

//        public EmailSender(EmailConfiguration emailConfig, IConfiguration configuration)
//        {
//            _emailConfig = emailConfig;
//            _siteSetting = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();
//        }

//        public void SendEmail(Message message)
//        {
//            var emailMessage = CreateEmailMessage(message);

//            Send(emailMessage);
//        }

//        public async Task SendEmailAsync(Message message)
//        {
//            var mailMessage = CreateEmailMessage(message);

//            await SendAsync(mailMessage);
//        }
//        public async Task SendEmailRegisterAsync(MessagebyURL message)
//        {
//            var mailMessage = CreateEmailRegisterMessage(message);

//            await SendAsync(mailMessage);
//        }

//        private MimeMessage CreateEmailMessage(Message message)
//        {
//            var emailMessage = new MimeMessage();
//            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
//            emailMessage.To.AddRange(message.To);
//            emailMessage.Subject = message.Subject;

//            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content) };

//            if (message.Attachments != null && message.Attachments.Any())
//            {
//                byte[] fileBytes;
//                foreach (var attachment in message.Attachments)
//                {
//                    using (var ms = new MemoryStream())
//                    {
//                        attachment.CopyTo(ms);
//                        fileBytes = ms.ToArray();
//                    }

//                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
//                }
//            }

//            emailMessage.Body = bodyBuilder.ToMessageBody();
//            return emailMessage;
//        }
//        private MimeMessage CreateEmailRegisterMessage(MessagebyURL message)
//        {
//            var emailMessage = new MimeMessage();
//            emailMessage.From.Add(new MailboxAddress(_emailConfig.From));
//            emailMessage.To.AddRange(message.To);
//            emailMessage.Subject = message.Subject;
//            var ssss = _siteSetting;
//            string ss = File.ReadAllText( (string.Format(AppContext.BaseDirectory + "Services\\EmailService\\themplate\\register.html")));
//            ss = (ss.Replace("\r\n", ""));
//            ss = ss.Replace("user", message.UserName);
//            ss = ss.Replace("url", _siteSetting.SiteInfo.Url);
//            ss = ss.Replace("company", _siteSetting.SiteInfo.CompanyInfo);
//            ss = ss.Replace("telephone", _siteSetting.SiteInfo.Phone);
//            var bodyBuilder = new BodyBuilder { HtmlBody = ss/*string.Format(ss, message.Content)*/ };

//            if (message.Attachments != null && message.Attachments.Any())
//            {
//                byte[] fileBytes;
//                foreach (var attachment in message.Attachments)
//                {
//                    using (var ms = new MemoryStream())
//                    {
//                        attachment.CopyTo(ms);
//                        fileBytes = ms.ToArray();
//                    }

//                    bodyBuilder.Attachments.Add(attachment.FileName, fileBytes, ContentType.Parse(attachment.ContentType));
//                }
//            }

//            emailMessage.Body = bodyBuilder.ToMessageBody();
//            return emailMessage;
//        }
//        private void Send(MimeMessage mailMessage)
//        {
//            using (var client = new SmtpClient())
//            {
//                try
//                {
//                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
//                    client.AuthenticationMechanisms.Remove("XOAUTH2");
//                    client.Authenticate(_emailConfig.UserName, _emailConfig.Password);

//                    client.Send(mailMessage);
//                }
//                catch
//                {
//                    //log an error message or throw an exception, or both.
//                    throw;
//                }
//                finally
//                {
//                    client.Disconnect(true);
//                    client.Dispose();
//                }
//            }
//        }

//        private async Task SendAsync(MimeMessage mailMessage)
//        {
//            using (var client = new SmtpClient())
//            {
//                try
//                {
//                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
//                    client.AuthenticationMechanisms.Remove("XOAUTH2");
//                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

//                    await client.SendAsync(mailMessage);
//                }
//                catch
//                {
//                    //log an error message or throw an exception, or both.
//                    throw;
//                }
//                finally
//                {
//                    await client.DisconnectAsync(true);
//                    client.Dispose();
//                }
//            }
//        }
//    }
//}
