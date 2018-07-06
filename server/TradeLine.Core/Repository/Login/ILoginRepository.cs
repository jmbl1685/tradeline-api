using TradeLine.Core.Entities;

namespace TradeLine.Core
{
    public interface ILoginRepository
    {
        User SignIn(Login login);
        string SignUp(User user);
    }
}
