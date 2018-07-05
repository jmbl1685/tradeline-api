using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TradeLine.API.Authorization
{
    public class CustomUnauthorizedResult : JsonResult
    {
        public CustomUnauthorizedResult(string message, int code)
            : base(new CustomError(message,code))
        {
            StatusCode = StatusCodes.Status401Unauthorized;
        }
    }
}