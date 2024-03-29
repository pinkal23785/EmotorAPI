using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.ServiceContracts;
using EMS.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        public ISkillsService _skillsService;
        public SkillsController(ISkillsService skillsService)
        {
            _skillsService = skillsService;

        }

        [Authorize]
        [HttpPost("add-skills")]
        public async Task<IActionResult> AddSkills(Skills skills)
        {
            try
            {
                await _skillsService.AddSkills(skills);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        
        [HttpGet("get-skills")]
        public async Task<IActionResult> GetSkills(bool IsMechanic)
        {
            try
            {
                var result = await _skillsService.GetSkills(IsMechanic);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("get-all-skills")]
        public async Task<IActionResult> GetAllSkills()
        {
            try
            {
                var result = await _skillsService.GetAllSkills();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}