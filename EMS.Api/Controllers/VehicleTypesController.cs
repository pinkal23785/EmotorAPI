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
    public class VehicleTypesController : ControllerBase
    {
        public IVehicleTypesService _vehicleTypesService;
        public VehicleTypesController(IVehicleTypesService vehicleTypesService)
        {
            _vehicleTypesService = vehicleTypesService;
        }
        
        [HttpGet("get-vehicle-types")]
        public async Task<IActionResult> GetVehicleTypes()
        {
            try
            {
                var result = await _vehicleTypesService.GetVehicleTypes();
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize()]
        [HttpPost("insert-vehicle-types")]
        public async Task<IActionResult> AddVehicleTypes(VehicleTypes vehicleTypes)
        {
            try
            {
                await _vehicleTypesService.AddVehicleTypes(vehicleTypes);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}