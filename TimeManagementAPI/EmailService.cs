using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using Models;

namespace TimeManagementAPI
{
    public class EmailService
    {

         private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(OvetimeClass3 record, string recipientEmail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(
                _configuration["EmailSettings:FromName"],
                _configuration["EmailSettings:FromEmail"]
            ));
            message.To.Add(new MailboxAddress("Recipient", recipientEmail));
            message.Subject = "New Time Entry Recorded";
            message.Body = new TextPart("plain")
            {
                Text = $"ID: {record.Id}\n" +
                       $"Name: {record.Name}\n" +
                       $"Time In: {record.TimeIn}\n" +
                       $"Time Out: {record.Timeout}\n"
            };

            using var client = new SmtpClient();
            client.Connect(_configuration["EmailSettings:SmtpHost"], int.Parse(_configuration["EmailSettings:SmtpPort"]), SecureSocketOptions.StartTls);


            client.Authenticate(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]);


            client.Send(message);


            client.Disconnect(true);
        }



    }
}



       