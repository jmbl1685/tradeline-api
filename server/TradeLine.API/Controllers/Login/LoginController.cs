using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TradeLine.API.Authorization.JsonWebToken;
using TradeLine.Core.Entities;
using TradeLine.Entities;

namespace TradeLine.API.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IConfiguration Configuration;
        JWTAuth jwt = null;

        public LoginController(IConfiguration configuration)
        {
            Configuration = configuration;
            jwt = new JWTAuth(Configuration);
        }

        [HttpPost, Route("signin")]
        public IActionResult SignIn([FromBody] Login login)
        {
            return Ok(new { token = jwt.GenerateToken(login) });
        }

        [HttpPost, Route("signup")]
        public IActionResult SignUp([FromBody] User user)
        {
            return Ok(new { message = "Hello World" });
        }

    }
}