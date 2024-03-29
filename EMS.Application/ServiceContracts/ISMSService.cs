using EMS.Application.DTO.SMS;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.ServiceContracts
{
   public interface ISMSService
    {
        Task<IRestResponse> SendSMS(SMSRequest request);
    }
}
