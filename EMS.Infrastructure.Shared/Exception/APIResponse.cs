using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Infrastructure.Shared.Exception
{
    public class APIResponse
    {
        public APIResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessage(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessage(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return "Bad Request";
                case 401:
                    return "Unauthorized";
                case 404:
                    return "Not Found";
                case 500:
                    return "Internal Server Error";
                default:
                    return "Something went wrong";

            };
        }

    }
}
