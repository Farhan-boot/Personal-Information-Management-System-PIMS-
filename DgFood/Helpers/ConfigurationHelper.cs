using Microsoft.Extensions.Configuration;
using PTSL.DgFood.Common.Model.EntityViewModels.MailSetup;
using System.IO;

namespace PTSL.DgFood.Api.Helpers
{
    public static class ConfigurationHelper
    {
        //public static string GetArivalURL()
        //{
        //    string baseURL = string.Empty;
        //    IConfigurationBuilder builder = new ConfigurationBuilder();
        //    builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
        //    var root = builder.Build();
        //    baseURL = root.GetSection("FidsAPISettings").GetSection("ArivalURL").Value;
        //    return baseURL;
        //}

        //public static string GetDepartureURL()
        //{
        //    string baseURL = string.Empty;
        //    IConfigurationBuilder builder = new ConfigurationBuilder();
        //    builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
        //    var root = builder.Build();
        //    baseURL = root.GetSection("FidsAPISettings").GetSection("DepartureURL").Value;
        //    return baseURL;
        //}

        public static SmsRequestConfiguration GetSmsApiConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            SmsRequestConfiguration smsConfiguration = new SmsRequestConfiguration
            {
                BaseUrl = root.GetSection("SmsSettings").GetSection("BaseUrl").Value,
                MethodUrl = root.GetSection("SmsSettings").GetSection("MethodUrl").Value,
                Apikey = root.GetSection("SmsSettings").GetSection("Apikey").Value,
                ApiType = root.GetSection("SmsSettings").GetSection("ApiType").Value,
                SenderId = root.GetSection("SmsSettings").GetSection("SenderId").Value,
            };
            return smsConfiguration;
        }
        public static EmailRequestConfiguration GetEmailApiConfiguration()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));
            var root = builder.Build();
            EmailRequestConfiguration emailConfiguration = new EmailRequestConfiguration
            {
                BaseUrl = root.GetSection("EmailConfigHelper").GetSection("BaseUrl").Value,
                Secretkey = root.GetSection("EmailConfigHelper").GetSection("Secretkey").Value,
                FromMail = root.GetSection("EmailConfigHelper").GetSection("FromMail").Value,
                ToMail = root.GetSection("EmailConfigHelper").GetSection("ToMail").Value,
                Subject = root.GetSection("EmailConfigHelper").GetSection("Subject").Value
            };
            return emailConfiguration;
        }
    }
}
