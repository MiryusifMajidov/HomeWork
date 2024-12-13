using InanceModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace InanceBL.Services
{
    public class EmailService
    {
        private readonly SmtpSetting _smtpSettings;
        

        public EmailService(IOptions<SmtpSetting> smtpSettings)
        {
            _smtpSettings = smtpSettings.Value; 
        }

        public void SendMail(string toEmail, string subject, string body)
        {
            try
            {
                var fromAddress = new MailAddress(_smtpSettings.UserName, "Miryusif");
                var toAddress = new MailAddress(toEmail);

                using (var smtp = new SmtpClient
                {
                    Host = _smtpSettings.Host,
                    Port = _smtpSettings.Port,
                    EnableSsl = _smtpSettings.EnableSsl,
                    Credentials = new NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password)
                })
                {
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    })
                    {
                        smtp.Send(message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("E-poçt göndərilməsində problem var: " + ex.Message);
            }
        }
    }
}
