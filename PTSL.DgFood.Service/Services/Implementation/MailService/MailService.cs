using Microsoft.Extensions.Options;
using MimeKit;
using PTSL.DgFood.Common.Model.EntityViewModels.MailSetup;
using PTSL.DgFood.Service.Services.Interface.MailService;
using System;
using System.IO;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using PTSL.DgFood.Common.Helper;
using MailKit.Security;

namespace PTSL.DgFood.Service.Services.Implementation.MailService
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        #region Send Mail


        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                var email = new MimeMessage();
                email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
                email.Subject = mailRequest.Subject;
                var builder = new BodyBuilder();
                if (mailRequest.Attachments != null)
                {
                    byte[] fileBytes;
                    foreach (var file in mailRequest.Attachments)
                    {
                        if (file.Length > 0)
                        {
                            using (var ms = new MemoryStream())
                            {
                                file.CopyTo(ms);
                                fileBytes = ms.ToArray();
                            }
                            builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                        }
                    }
                }
                builder.HtmlBody = mailRequest.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
            catch (Exception e)
            {

                throw;
            }

        }
        public async Task SendMobileAsync(SmsRequest smsRequest, SmsRequestConfiguration smsConfiguration)
        {
            try
            {
                string url = smsConfiguration.BaseUrl + smsConfiguration.MethodUrl;
                string sendSmsUrl = url + "?api_key=" + smsConfiguration.Apikey + "&type=" + smsConfiguration.ApiType + "&contacts=" + smsRequest.ToContactNumber + "&senderid=" + smsConfiguration.SenderId + "&msg=" + smsRequest.Message + "";
                await HttpApiHelper.SendSmsAsync(sendSmsUrl);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}