using AutoMapper;
using PTSL.DgFood.Common.Model.EntityViewModels.MailSetup;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTSL.DgFood.Service.Services.Interface.MailService
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendMobileAsync(SmsRequest smsRequest, SmsRequestConfiguration smsConfiguration);
    }
}