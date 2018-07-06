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
            User user = null;
            object response = new { error = "User not found" };

            if (ModelState.IsValid) { }
                user = repository.SignIn(login);

            if (user != null)
                response = new { token = jwt.GenerateToken(user) };

            return Ok(response);
        }

        [HttpPost, Route("signup")]
        public IActionResult SignUp([FromBody] User user)
        {
            string Response = null;

            if (ModelState.IsValid)
                Response = repository.SignUp(user);

            return Ok(new { state = Response });
        }

    }
}