using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EMS.Application.DTO.Customers;
using EMS.Application.ServiceContracts;
using EMS.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private ICustomerVehicleService _customerVehicleService;
        public CustomerController(ICustomerVehicleService customerVehicleService)
        {
            _customerVehicleService = customerVehicleService;
        }

        [Authorize]
        [HttpPost("add-customer-vehicle")]
        public async Task<IActionResult> AddCustomerVehicle(CustomerVehicleViewModel customerVehicle)
        {
            try
            {
                int UserId = User.GetId();
                await _customerVehicleService.AddCustomerVehicle(customerVehicle,UserId);
                return Ok();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}