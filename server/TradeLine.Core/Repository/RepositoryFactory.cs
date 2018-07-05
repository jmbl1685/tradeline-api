using System;
using System.Collections.Generic;
using System.Text;

namespace TradeLine.Core.Repository
{
    public static class RepositoryFactory
    {
        public static LoginRepository GetLoginRepository() => new LoginRepository();
    }
}
