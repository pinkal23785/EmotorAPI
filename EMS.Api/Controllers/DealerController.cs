using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTO.Dealers;
using EMS.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerController : ControllerBase
    {

        IDealerService _dealerService;
        public DealerController(IDealerService dealerService)
        {
            _dealerService = dealerService;
        }

        [HttpPost("NewDealer")]
        public async Task<IActionResult> NewDealer(NewDealerRequest newDealer)
        {
            try
            {
                int UserId = int.Parse(User.Claims.Where(x => x.Type == "id").Select(x => x.Value).First());
                await _dealerService.NewDealer(newDealer, UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}