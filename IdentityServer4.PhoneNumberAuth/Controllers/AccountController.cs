using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EMS.Application.DTO.SMS;
using EMS.Application.ServiceContracts;
using EMS.Infrastructure.Shared.Exception;
using IdentityServer4.Models;
using IdentityServer4.PhoneNumberAuth.Models;

using IdentityServer4.PhoneNumberAuth.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IdentityServer4.PhoneNumberAuth.Controllers
{
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISMSService _smsService;
        private readonly DataProtectorTokenProvider<ApplicationUser> _dataProtectorTokenProvider;
        private readonly PhoneNumberTokenProvider<ApplicationUser> _phoneNumberTokenProvider;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;

        public AccountController(
            IConfiguration configuration,
            ISMSService smsService,
            DataProtectorTokenProvider<ApplicationUser> dataProtectorTokenProvider,
            PhoneNumberTokenProvider<ApplicationUser> phoneNumberTokenProvider,
            UserManager<ApplicationUser> userManager, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            _smsService = smsService ?? throw new ArgumentNullException(nameof(smsService));

            _dataProtectorTokenProvider = dataProtectorTokenProvider
                                          ?? throw new ArgumentNullException(nameof(dataProtectorTokenProvider));

            _phoneNumberTokenProvider = phoneNumberTokenProvider
                                        ?? throw new ArgumentNullException(nameof(phoneNumberTokenProvider));

            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));

            _claimsFactory = claimsFactory ?? throw new ArgumentNullException(nameof(claimsFactory));
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel user)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var userExist = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == user.PhoneNumber);
                if (userExist == null)
                {
                    var appUser = new ApplicationUser()
                    {
                        UserName = user.PhoneNumber,
                        NormalizedUserName = user.PhoneNumber,
                        PhoneNumber = user.PhoneNumber
                    };
                    await _userManager.CreateAsync(appUser);

                    PhoneLoginViewModel model = new PhoneLoginViewModel()
                    {
                        PhoneNumber = user.PhoneNumber
                    };

                    var response = await SendOTP(model);
                    return response;
                }
                else
                {
                    return BadRequest(new APIResponse(400, "User with mobile number already exist"));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost("SendOTP")]
        public async Task<IActionResult> SendOTP([FromBody] PhoneLoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                bool IsNewUser = false;
                //var user = await GetUser(model);
                ApplicationUser user = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == model.PhoneNumber);
                if (user == null)
                {
                    user = new ApplicationUser()
                    {
                        UserName = model.PhoneNumber,
                        NormalizedUserName = model.PhoneNumber,
                        PhoneNumber = model.PhoneNumber,
                        UserType = model.UserType,
                        IsActive = true,
                        IsLocked = false,
                        IsVerified = false
                        
                    };
                    await _userManager.CreateAsync(user);
                    IsNewUser = true;
                }

                var response = await SendSmsRequet(model, user);

                if (!response.Result)
                {
                    return BadRequest("Sending sms failed");
                }

                var resendToken = await _dataProtectorTokenProvider.GenerateAsync("resend_token", _userManager, user);
                var body = GetBody(model.PhoneNumber, response.VerifyToken, resendToken, IsNewUser);

                return Accepted(body);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //[HttpPut("SendOTP")]
        //public async Task<IActionResult> SendOTP(string resendToken, [FromBody] PhoneLoginViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = await GetUser(model);
        //    if (!await _dataProtectorTokenProvider.ValidateAsync("resend_token", resendToken, _userManager, user))
        //    {
        //        return BadRequest("Invalid resend token");
        //    }

        //    var response = await SendSmsRequet(model, user);

        //    if (!response.Result)
        //    {
        //        return BadRequest("Sending sms failed");
        //    }

        //    var newResendToken = await _dataProtectorTokenProvider.GenerateAsync("resend_token", _userManager, user);
        //    var body = GetBody(model.PhoneNumber, response.VerifyToken, newResendToken);
        //    return Accepted(body);
        //}

        private async Task<ApplicationUser> GetUser(PhoneLoginViewModel loginViewModel)
        {
            try
            {
                var phoneNumber = _userManager.NormalizeName(loginViewModel.PhoneNumber);
                var user = await _userManager.Users.SingleOrDefaultAsync(x => x.PhoneNumber == phoneNumber);
                //if (user == null)
                //{
                //    user = new ApplicationUser()
                //    {

                //        UserName = loginViewModel.PhoneNumber,
                //        NormalizedUserName = loginViewModel.FirstName +" " + loginViewModel.LastName,
                //        PhoneNumber = loginViewModel.PhoneNumber

                //    };
                //    await _userManager.CreateAsync(user);
                //}
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<(string VerifyToken, bool Result)> SendSmsRequet(PhoneLoginViewModel model,
            ApplicationUser user)
        {

            var verifyToken = await _phoneNumberTokenProvider.GenerateAsync("verify_number", _userManager, user);

            var smsRequestBody = new SMSRequest()
            {
                MobileNumber = model.PhoneNumber,
                Message = $"Your login verification code is: {verifyToken}"
            };
            // var result = await _smsService.SendSMS(smsRequestBody);

            return (verifyToken, true);
        }

        private Dictionary<string, string> GetBody(string phoneNumber, string verifyToken, string resendToken, bool IsNewUser)
        {
            var body = new Dictionary<string, string> { { "resend_token", resendToken } };
            body.Add("PhoneNumber", phoneNumber);
            if (_configuration["ReturnVerifyTokenForTesting"] == bool.TrueString)
            {
                body.Add("verify_token", verifyToken);
            }
            body.Add("isNewUser", IsNewUser.ToString());
            return body;
        }
    }
}