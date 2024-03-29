using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
       
        private readonly IConfigIssuesService _configIssuesService;
        private readonly IPartnerIssueService _partnerIssueService;
         public ServiceController( IConfigIssuesService configIssuesService,
             IPartnerIssueService partnerIssueService)
        {
            _configIssuesService = configIssuesService;
            _partnerIssueService = partnerIssueService;
        }

       

        [HttpGet("get-service-issue")]
        public async Task<IActionResult> GetServiceIssues(int ServiceId, int? ParentId)
        {
            try
            {
                var result = await _configIssuesService.GetServiceIssuesBySkillId(ServiceId, ParentId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize()]
        [HttpGet("get-partner-service-issue")]
        public async Task<IActionResult> GetPartnerServiceIssues()
        {
            try
            {
                int UserId = User.GetId();
                var result = await _partnerIssueService.GetPartnerServiceIssues(UserId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-popular-service")]
        public async Task<IActionResult> GetPopularService()
        {
            try
            {
                var result = await _configIssuesService.GetPopularService();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-service-by-level")]
        public async Task<IActionResult> GetServiceByLevel(int? SkillId, int? ServiceId)
        {
            try
            {
                var result = await _configIssuesService.GetServiceByLevel(SkillId,ServiceId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-skills")]
        public async Task<IActionResult> GetSkills()
        {
            try
            {
                var result = await _configIssuesService.GetAllSkills();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}