using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;

namespace AzureEmailing
{
    public class SendEmailTimer
    {
        [FunctionName("SendEmailTimer")]
        [return: SendGrid(ApiKey = "SendGridApiKey")]
        public SendGridMessage Run([TimerTrigger("*/100000 * * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"SendEmailTimer executed at: {DateTime.Now}");

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("bdittme@outlook.com", "Blake Dittmer"),
                Subject = "TESTER",
                PlainTextContent = "Text Context",
                HtmlContent = "Html Content, <strong>Functions are fun!</strong>"
            };
            msg.AddTo(new EmailAddress("blakedittmer@yahoo.com", "Blake Dittmer"));

            return msg;
        }
    }
}
