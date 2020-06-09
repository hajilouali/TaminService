//using Microsoft.AspNetCore.Http;
//using MimeKit;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace Services.Services.EmailService
//{
//    public class Message
//    {
//        public List<MailboxAddress> To { get; set; }
//        public string Subject { get; set; }
//        public string Content { get; set; }

//        public IFormFileCollection Attachments { get; set; }

//        public Message(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments)
//        {
//            To = new List<MailboxAddress>();

//            To.AddRange(to.Select(x => new MailboxAddress(x)));
//            Subject = subject;
//            Content = content;
//            Attachments = attachments;
//        }
//    }
//    public class MessagebyURL
//    {
//        public List<MailboxAddress> To { get; set; }
//        public string Subject { get; set; }
//        public string Url { get; set; }
//        public string UserName { get; set; }

//        public IFormFileCollection Attachments { get; set; }

//        public MessagebyURL(IEnumerable<string> to, string subject, string url,string userName, IFormFileCollection attachments)
//        {
//            To = new List<MailboxAddress>();

//            To.AddRange(to.Select(x => new MailboxAddress(x)));
//            Subject = subject;
//            Url = url;
//            Attachments = attachments;
//            UserName = userName;
//        }
//    }
//}
