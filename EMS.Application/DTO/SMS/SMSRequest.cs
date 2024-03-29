using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Application.DTO.SMS
{
    public class SMSRequest
    {
        public string MobileNumber { get; set; }
        public string Message { get; set; }
    }
}
