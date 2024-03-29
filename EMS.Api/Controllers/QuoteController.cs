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
    public class QuoteController : ControllerBase
    {
        private readonly IQuotationService _quotationService;
        public QuoteController(IQuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        [Authorize()]
        [HttpPost("create-quote")]
        public async Task<IActionResult> CreateQuote(CustomerQuotationViewModel quotations)
        {
            try
            {
                quotations.quotationInfo.CustomerId = User.GetId();
                await _quotationService.CreateQuotation(quotations);
                return Ok("success");
            }
            catch (Exception ex)
            {
               return this.StatusCode(500,ex.Message);
            }
        }

        [Authorize()]
        [HttpGet("get-quote")]
        public async Task<IActionResult> GetQuote()
        {
            try
            {
                var result = await _quotationService.GetMechanicQuote(User.GetId());
                return Ok(result);
            }
            catch(Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }
        [Authorize()]
        [HttpGet("get-quote-issue")]
        public async Task<IActionResult> GetQuoteIssue(int QuotationId)
        {
            try
            {
                var result = await _quotationService.GetQuoteDetails(QuotationId ,User.GetId());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return this.StatusCode(500, ex.Message);
            }
        }

    }
}