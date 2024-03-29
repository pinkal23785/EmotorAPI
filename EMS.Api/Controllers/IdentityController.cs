using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EMS.Api.ViewModel;
using EMS.Application.ServiceContracts;
using EMS.Infrastructure.Shared.Exception;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        public IConfiguration Configuration;
        public IUserService _userService;
        public IdentityController(IConfiguration configuration, IUserService userService)
        {
            Configuration = configuration;
            _userService = userService;
        }

        [HttpPost("VerifyOTP")]
        public async Task<IActionResult> VerifyOTP([FromBody] PhoneVerificationModel model)
        {
            try
            {
                var result = await ClientDiscovery(model.PhoneNumber, model.VerifyToken);
                return Accepted(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse(500, ex.Message));
            }
        }
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            return Ok(User.Claims.Where(x => x.Type == "phone_number").Select(x => new { x.Type, x.Value }));
        }



        private async Task<Dictionary<string, string>> ClientDiscovery(string PhoneNumber, string VerifyToken)
        {
            try
            {
                var discoURL = Configuration["DiscoveryURL"];
                var client = new HttpClient();
                var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
                {
                    Address = discoURL,
                    Policy =
                    {
                        RequireHttps=false
                    }
                });
                if (disco.IsError)
                {

                }

                var tokenRequest = new TokenRequest
                {
                    GrantType = "phone_number_token",
                    ClientId = "ems_authentication",
                    ClientSecret = "oVAL5ZjyAb9W93cbbdAj43rTD35fXmjz",
                    Address = disco.TokenEndpoint,
                    Parameters = new Dictionary<string, string>
                {
                    {"phone_number", PhoneNumber},
                    {"verification_token", VerifyToken}
                }
                };
                var tokenResponse = await client.RequestTokenAsync(tokenRequest);

                if (tokenResponse.IsError)
                {

                }

                var handler = new JwtSecurityTokenHandler();
                var decodedValue = handler.ReadJwtToken(tokenResponse.AccessToken);
                var IsOldUser = await _userService.IsUserFound(int.Parse(decodedValue.Subject));
                var result = new Dictionary<string, string>()
                {
                    { "access_token",tokenResponse.AccessToken},
                    { "expires_in",tokenResponse.ExpiresIn.ToString()},
                    { "token_type",tokenResponse.TokenType},
                    { "refresh_token",tokenResponse.RefreshToken},
                    { "IsOldUser",IsOldUser.ToString()},
                };
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet("refresh_token")]
        public async Task<IActionResult> RefreshToken(string refresh_token)
        {
            try
            {
                var discoURL = Configuration["DiscoveryURL"];
                var client = new HttpClient();
                var disco = await client.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
                {
                    Address = discoURL,
                    Policy =
                    {
                        RequireHttps=false
                    }
                });
                if (disco.IsError)
                {

                }

                var tokenRequest = new TokenRequest
                {
                    GrantType = "refresh_token",
                    ClientId = "ems_authentication",
                    ClientSecret = "oVAL5ZjyAb9W93cbbdAj43rTD35fXmjz",
                    Address = disco.TokenEndpoint,
                    Parameters = new Dictionary<string, string>
                {
                    {"refresh_token", refresh_token},
                    
                }
                };
                var tokenResponse = await client.RequestTokenAsync(tokenRequest);

                if (tokenResponse.IsError)
                {
                    throw new Exception(tokenResponse.Error);
                }

                var handler = new JwtSecurityTokenHandler();
                var decodedValue = handler.ReadJwtToken(tokenResponse.AccessToken);
                var IsOldUser = await _userService.IsUserFound(int.Parse(decodedValue.Subject));
                var result = new Dictionary<string, string>()
                {
                    { "access_token",tokenResponse.AccessToken},
                    { "expires_in",tokenResponse.ExpiresIn.ToString()},
                    { "token_type",tokenResponse.TokenType},
                    { "refresh_token",tokenResponse.RefreshToken},
                    { "IsOldUser",IsOldUser.ToString()},
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                this.StatusCode(500);
                return BadRequest(ex.Message);
            }
        }
    }
}