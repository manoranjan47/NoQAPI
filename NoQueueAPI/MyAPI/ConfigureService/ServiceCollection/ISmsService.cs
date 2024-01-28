using DataAccessLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace MyAPI.ConfigureService.ServiceCollection
{
    public interface ISmsService
    {
        public Task<MessageResource> SendSMS(string To,string Otp);
    }
}
