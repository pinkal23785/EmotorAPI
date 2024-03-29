using Microsoft.AspNetCore.Identity;

namespace IdentityServer4.PhoneNumberAuth.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public bool? IsActive { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsVerified { get; set; }
        public byte? UserType { get; set; }

    }
}