using EMS.Application.DTO.Emails;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.ServiceContracts
{
    public interface IEmailService
    {
        Task SendEmail(EmailRequest request);
    }
}
