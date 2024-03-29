using System;
using System.Collections.Generic;
using System.Text;

namespace EMS.Application.DTO.Emails
{
    public class EmailRequest
    {
        public string Name { get; set; }
        public string EmailFrom { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
