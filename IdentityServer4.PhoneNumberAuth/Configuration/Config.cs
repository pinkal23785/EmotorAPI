using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.PhoneNumberAuth.Constants;

namespace IdentityServer4.PhoneNumberAuth.Configuration
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone()
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource ("emsapi", "EMS Api") {
                    UserClaims = { JwtClaimTypes.Role, JwtClaimTypes.PhoneNumber, JwtClaimTypes.Id } }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "ems_authentication",
                    AllowedGrantTypes = new List<string> { AuthConstants.GrantType.PhoneNumberToken},
                    ClientSecrets = {new Secret("oVAL5ZjyAb9W93cbbdAj43rTD35fXmjz".Sha256())},
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.OfflineAccess,
                        "emsapi"
                    },
                    AllowOfflineAccess = true,
                    AccessTokenLifetime = 50,
                    //IdentityTokenLifetime=10,
                    RefreshTokenExpiration=TokenExpiration.Sliding,
                    SlidingRefreshTokenLifetime=1296000,
                    RefreshTokenUsage=TokenUsage.ReUse,
                    

                }
            };
        }
    }
}
