using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Email
{
	public class EmailService : IEmailService
	{
		private readonly IConfiguration _configuration;

		public EmailService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task SendEmailAsync(string toEmail, string subject, string body)
		{
			var smtpSettings = _configuration.GetSection("SmtpSettings");
			var smtpServer = smtpSettings["Host"];
			var smtpPort = int.Parse(smtpSettings["Port"]);
			var smtpUsername = smtpSettings["Username"];
			var smtpPassword = smtpSettings["Password"];

			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Your Name", smtpUsername));
			message.To.Add(new MailboxAddress("", toEmail));
			message.Subject = subject;

			var textPart = new TextPart("plain")
			{
				Text = body
			};

			message.Body = textPart;

			using (var client = new SmtpClient())
			{
				await client.ConnectAsync(smtpServer, smtpPort, false);
				await client.AuthenticateAsync(smtpUsername, smtpPassword);
				await client.SendAsync(message);
				await client.DisconnectAsync(true);
			}
		}
	}
}
