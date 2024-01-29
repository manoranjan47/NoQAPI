using DataAccessLibrary.DTO;
using DataAccessLibrary.IServices;
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Clients;
using Twilio.Http;
using Twilio.Rest.Api.V2010.Account;
using Twilio.TwiML.Messaging;
using Twilio.Types;
using static System.Net.WebRequestMethods;

namespace MyAPI.ConfigureService.ServiceCollection
{
    public class SmsService: ISmsService
    {
        //private readonly ITwilioRestClient _twilioClient;
        private readonly IConfiguration _config;
        public SmsService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<MessageResource> SendSMS(string To, string Otp)
        {
            TwilioClient.Init(_config["Twilio:sid"], _config["Twilio:token"]);
            var messageBody = 
                          $"Dear User,\n\n" +
                          $"Thank you for using our service. Your One-Time Password (OTP) for verification is:\n\n" +
                          $"{Otp}\n\n" +
                          $"Best regards,\n" +
                          $"Team NoQ";
            //var messageBody = $"Your One-Time Password (OTP) for verification is: {Otp}"+ " $\"Your Company Name\";";
            var result = await MessageResource.CreateAsync(
                  body: messageBody,
                  from: new PhoneNumber(_config["Twilio:from"]),
                  to: new PhoneNumber("+91"+To)
              );
            return result;
        }
    }
}
