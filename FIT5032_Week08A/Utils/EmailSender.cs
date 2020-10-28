using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FIT5032_Week08A.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("jobson.monash@gmail.com", "Good good study, Day day up");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

        public void SendWithAttachment(String toEmail, String subject, String contents, String path, String fileName)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("jobson.monash@gmail.com", "Good good study, Day day up");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            var attach = File.ReadAllBytes(path);

            msg.AddAttachment(fileName, Convert.ToBase64String(attach));

            var response = client.SendEmailAsync(msg);
        }

    }
}