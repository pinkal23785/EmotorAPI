using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTO.Emails;
using EMS.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("send-email")]
        public async Task<IActionResult> SendEmail(EmailRequest request)
        {
            try
            {
                await _emailService.SendEmail(request);
                return Ok();
            }
            catch (Exception ex)
            {
                this.StatusCode(500);
                return BadRequest(ex.Message);
            }
        }
    }
}