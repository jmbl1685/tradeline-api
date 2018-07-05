using System.Data.SqlClient;
using TradeLine.Core.DBConnection.Credentials;

namespace TradeLine.Core
{
    public static class _SQLConnection
    {
        private static string ConnectionString = Credentials.SQLCredential();
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
