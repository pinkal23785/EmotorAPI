using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTO.Mechanics;
using EMS.Application.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicController : ControllerBase
    {
        IMechanicService _mechanicService;
        public MechanicController(IMechanicService mechanicService)
        {
            _mechanicService = mechanicService;
        }

        [Authorize()]
        [HttpPost("NewMechanic")]
        public async Task<IActionResult> NewMechanic(NewMechanicRequest newMechanic)
        {
            try
            {
                int UserId = User.GetId();
                await _mechanicService.NewMechanic(newMechanic, UserId);
                return Ok("success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [Authorize()]
        [HttpGet("get-mechanic-skills")]
        public async Task<IActionResult> GetMechanicSkills()
        {
            try
            {
                int UserId = User.GetId();
                var result = await _mechanicService.GetMechanicSkills(UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpPost("search-service-mechanics")]
        public async Task<IActionResult> SearchRequestedServiceMechanic([FromBody]MechanicSearchRequest searchRequest)
        {
            try
            {
                var result = await _mechanicService.SearchRequestedServiceMechanic(searchRequest);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("get-geography")]
        public async Task<IActionResult> GetLocation(string lat, string lon)
        {
            var result = await _mechanicService.GetLocation(lat, lon);
            return Ok(result);
        }

        
    }
}