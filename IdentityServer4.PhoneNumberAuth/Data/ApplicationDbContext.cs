using IdentityServer4.PhoneNumberAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer4.PhoneNumberAuth.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}