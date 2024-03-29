using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizeController : ControllerBase
    {
        private readonly ILocaliseLangService _localiseLangService;
        public LocalizeController(ILocaliseLangService localiseLangService)
        {
            _localiseLangService = localiseLangService;
        }

        [HttpGet("get-localize-lang")]
        public async Task<IActionResult> GetLocalizeLang()
        {
            try
            {
                var result = await _localiseLangService.getLocalizeLang();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-states")]
        public async Task<IActionResult> GetAllStates()
        {
            try
            {
                var result = await _localiseLangService.getAllStates();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}