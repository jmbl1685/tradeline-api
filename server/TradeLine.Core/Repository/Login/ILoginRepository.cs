using TradeLine.Core.Entities;

namespace TradeLine.Core
{
    public interface ILoginRepository
    {
        void SignIn(Login login);
        void SignUp(User user);
    }
}
