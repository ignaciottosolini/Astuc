using Astuc.Domain.DTOs;
using Astuc.Domain.Entities;
using AutoMapper;
using EIRL.Application.Services.Common;
using EIRL.Infrastructure.Data;
using EIRL.Infrastructure.Repositories.Common;
using MailKit.Security;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIRL.Application.Services
{
    public interface ISendEmailService 
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
    
    public class SendEmailService : ISendEmailService
    {
        public SendEmailService() { }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            var address = "info@astuc.org";
            var pass = "userB01.";
            emailMessage.From.Add(new MailboxAddress(subject, address));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = message };
            try
            {

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync("smtp.hostinger.com", 465, SecureSocketOptions.Auto);
                    await client.AuthenticateAsync(address, pass);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}

