using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.Events;
using IdentityServer4.Models;
using IdentityServer4.PhoneNumberAuth.Models;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IdentityServer4.PhoneNumberAuth.Validation
{
    public class PhoneNumberTokenGrantValidator : IExtensionGrantValidator
    {
        private readonly PhoneNumberTokenProvider<ApplicationUser> _phoneNumberTokenProvider;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEventService _events;
        private readonly ILogger<PhoneNumberTokenGrantValidator> _logger;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;

        public PhoneNumberTokenGrantValidator(
            PhoneNumberTokenProvider<ApplicationUser> phoneNumberTokenProvider,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEventService events,
            ILogger<PhoneNumberTokenGrantValidator> logger,
            IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory)
        {
            _phoneNumberTokenProvider = phoneNumberTokenProvider;
            _userManager = userManager;
            _signInManager = signInManager;
            _events = events;
            _logger = logger;
            _claimsFactory = claimsFactory;
        }

        public async Task ValidateAsync(ExtensionGrantValidationContext context)
        {
            var createUser = false;
            var raw = context.Request.Raw;
            var credential = raw.Get(OidcConstants.TokenRequest.GrantType);
            if (credential == null || credential != Constants.AuthConstants.GrantType.PhoneNumberToken)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant,
                    "invalid verify_phone_number_token credential");
                return;
            }

            var phoneNumber = raw.Get(Constants.AuthConstants.TokenRequest.PhoneNumber);
            var verificationToken = raw.Get(Constants.AuthConstants.TokenRequest.Token);

            var user = await _userManager.Users.SingleOrDefaultAsync(x =>
                x.PhoneNumber == _userManager.NormalizeName(phoneNumber));
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = phoneNumber,
                    PhoneNumber = phoneNumber,
                    SecurityStamp = new Secret("oVAL5ZjyAb9W93cbbdAj43rTD35fXmjz").Value + phoneNumber.Sha256()
                };
                createUser = true;
            }

            var result =
                await _phoneNumberTokenProvider.ValidateAsync("verify_number", verificationToken, _userManager, user);
            if (!result)
            {
                _logger.LogInformation("Authentication failed for token: {token}, reason: invalid token",
                    verificationToken);
                await _events.RaiseAsync(new UserLoginFailureEvent(verificationToken,
                    "invalid token or verification id", false));
                return;
            }

            if (createUser)
            {
                user.PhoneNumberConfirmed = true;
                var resultCreation = await _userManager.CreateAsync(user);
                if (resultCreation != IdentityResult.Success)
                {
                    _logger.LogInformation("User creation failed: {username}, reason: invalid user", phoneNumber);
                    await _events.RaiseAsync(new UserLoginFailureEvent(phoneNumber,
                        resultCreation.Errors.Select(x => x.Description).Aggregate((a, b) => a + ", " + b), false));
                    return;
                }
            }

            _logger.LogInformation("Credentials validated for username: {phoneNumber}", phoneNumber);
            await _events.RaiseAsync(new UserLoginSuccessEvent(phoneNumber, user.Id.ToString(), phoneNumber, false));
            await _signInManager.SignInAsync(user, true);
            
            context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.ConfirmationBySms);
        }

        public string GrantType => Constants.AuthConstants.GrantType.PhoneNumberToken;
    }
}