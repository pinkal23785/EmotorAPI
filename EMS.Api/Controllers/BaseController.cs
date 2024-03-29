using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public int UserId;
        public BaseController()
        {
            if (User.Claims.Where(x => x.Type == "id").Select(x => x.Value).FirstOrDefault() != null)
                UserId = int.Parse(User.Claims.Where(x => x.Type == "id").Select(x => x.Value).First());
        }
       
    }
}