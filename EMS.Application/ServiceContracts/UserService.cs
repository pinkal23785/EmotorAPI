using EMS.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.ServiceContracts
{
    public interface IUserService
    {
        Task<bool> IsUserFound(int UserId);
    }
    public class UserService : IUserService
    {
        private EMSContext _context;
        public UserService(EMSContext context)
        {
            _context = context;
        }
        public async Task<bool> IsUserFound(int UserId)
        {
            var user = _context.Users.Any(x => x.UserId == UserId);
            return user;
        }
    }
}
