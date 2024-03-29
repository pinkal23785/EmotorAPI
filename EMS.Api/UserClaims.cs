using IdentityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EMS.Api
{
    public static class UserClaims
    {
        public static int GetId(this ClaimsPrincipal principal)
        {
            return int.Parse(principal?.FindFirst(x => x.Type.Equals(JwtClaimTypes.Id))?.Value);
        }
    }
}
