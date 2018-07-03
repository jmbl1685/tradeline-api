using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TradeLine.API.Authorization.JsonWebToken;

namespace TradeLine.API.Controllers
{
    [Route("api")]
    [Authorize]
    public class UserController : Controller
    {

        [Route("user")]
        public IActionResult GetUser() => Ok(new { data = "Hello World" });

    }
}
