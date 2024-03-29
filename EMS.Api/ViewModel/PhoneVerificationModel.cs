using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Api.ViewModel
{
    public class PhoneVerificationModel
    {
        public string PhoneNumber { get; set; }
        public string VerifyToken { get; set; }
    }

}
