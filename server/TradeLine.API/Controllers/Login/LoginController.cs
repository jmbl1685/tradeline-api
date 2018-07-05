using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TradeLine.API.Authorization.JsonWebToken;
using TradeLine.Core;
using TradeLine.Core.Entities;
using TradeLine.Core.Repository;

namespace TradeLine.API.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private static LoginRepository repository = RepositoryFactory.GetLoginRepository();

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
            
            if (ModelState.IsValid) 
                repository.SignUp(user);

            return Ok(new { message = "Hello World" });
        }

    }
}