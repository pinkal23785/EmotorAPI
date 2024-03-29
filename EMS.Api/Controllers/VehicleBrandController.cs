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
    public class VehicleBrandController : ControllerBase
    {
        public IVehicleBrandService _vehicleBrandService;
        public VehicleBrandController(IVehicleBrandService vehicleBrandService)
        {
            _vehicleBrandService = vehicleBrandService;
        }
        
        [HttpPost("add-vehicle-brand")]
        public async Task<IActionResult> AddVehicleBrand(VehicleBrands brands)
        {
            try
            {
                await _vehicleBrandService.AddVehicleBrand(brands);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpGet("get-vehicle-brand")]
        public async Task<IActionResult> GetVehicleBrand(int vehicleTypeId)
        {
            try
            {
                var result = await _vehicleBrandService.GetVehicleBrands(vehicleTypeId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-vehicle-brand-by-type")]
        public async Task<IActionResult> GetVehicleBrandsByType(string type)
        {
            try
            {
                var result = await _vehicleBrandService.GetVehicleBrandsByType(type);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("get-vehicle-model")]
        public async Task<IActionResult> GetVehicleModel(int BrandId)
        {
            try
            {
                var result = await _vehicleBrandService.GetVehicleModels(BrandId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}