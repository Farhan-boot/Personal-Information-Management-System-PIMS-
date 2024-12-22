using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace PTSL.DgFood.Common.Model.EntityViewModels.MailSetup
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<IFormFile> Attachments { get; set; }
    }
    public class SmsRequest
    {
        public string ToContactNumber { get; set; }
        public string Message { get; set; }
    }
    public class SmsRequestConfiguration
    {
        public string BaseUrl { get; set; }
        public string MethodUrl { get; set; }
        public string Apikey { get; set; }
        public string ApiType { get; set; }
        public string SenderId { get; set; }
        //public string MessageBangla { get; set; }
    }
    public class EmailRequestConfiguration
    {
        public string BaseUrl { get; set; }
        public string Secretkey { get; set; }
        public string FromMail { get; set; }
        public string ToMail { get; set; }
        public string Subject { get; set; }
    }
    public class EmailApi
    {
        public string secretkey { get; set; }
        public string FromMail { get; set; }
        public string[] ToMail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}