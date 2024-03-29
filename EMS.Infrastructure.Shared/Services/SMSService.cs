using EMS.Application.Configurations;
using EMS.Application.DTO.SMS;
using EMS.Application.ServiceContracts;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Infrastructure.Shared.Services
{
    public class SMSService : ISMSService
    {
        private readonly IOptions<SMSConfigurations> configurationService;
        public SMSService(IOptions<SMSConfigurations> _configurationService)
        {
            configurationService = _configurationService;
        }
        public async Task<IRestResponse> SendSMS(SMSRequest model)
        {
            var taskCompletionSource = new TaskCompletionSource<IRestResponse>();

            //var client = new RestClient(string.Format("{0}?apikey={1}&message={2}&sender={3}&numbers={4}",
            //    configurationService.Value.SMSApiUrl, configurationService.Value.Auth_Key, model.Message,
            //    configurationService.Value.SenderId, model.MobileNumber));
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Cache-Control", "no-cache");
            //IRestResponse response = client.Execute(request);


            //var client = new RestClient(configurationService.Value.SMSApiUrl);
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("content-type", "application/json");
            //request.AddHeader("authkey", configurationService.Value.Auth_Key);
            //request.AddParameter("application/json", JsonConvert.SerializeObject(model), ParameterType.RequestBody);

            var client = new RestClient(
                
                string.Format("https://www.fast2sms.com/dev/bulk?authorization={0}&sender_id={1}&message={2}&language={3}&route={4}&numbers={5}",
                "2tdMiIyQBkNuf4De8GKHzv596PJlhw7WjsOUr3g1LcVZSxmAaEaxX1ij5AGNgZdJVDsu6BYtlkywRICf","eMotor",model.Message,"english","p", model.MobileNumber));
            var request = new RestRequest(Method.GET);
            //IRestResponse response = client.Execute(request);

            client.ExecuteAsync(request, restResponse =>
            {
                if (restResponse.ErrorException != null)
                {
                    const string message = "Error retrieving response.";
                    //throw new ApplicationException(message, restResponse.ErrorException);
                }
                 taskCompletionSource.SetResult(restResponse);
            });
            return await taskCompletionSource.Task as IRestResponse;
        }
    }
}
