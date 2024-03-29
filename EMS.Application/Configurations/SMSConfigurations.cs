using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Application.Configurations
{
    public class SMSConfigurations
    {
        public string SMSApiUrl { get; set; }
        public string Auth_Key { get; set; }
        public string SenderId { get; set; }
        public string RouteId { get; set; }
        public string Country { get; set; }
        public string smsContentType { get; set; }
    }
}
