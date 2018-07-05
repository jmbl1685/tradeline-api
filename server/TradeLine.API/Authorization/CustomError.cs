namespace TradeLine.API.Authorization
{
    public class CustomError
    {
        public string Error { get; }
        public int Code { get; set; }

        public CustomError(string message, int code)
        {
            Error = message;
            Code = code;
        }
    }
}