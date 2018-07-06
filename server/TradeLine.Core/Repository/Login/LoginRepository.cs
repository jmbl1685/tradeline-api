using System.Data.SqlClient;
using TradeLine.Core.Entities;

namespace TradeLine.Core
{
    public class LoginRepository : ILoginRepository
    {

        public User SignIn(Login login)
        {
            bool flag = false;
            User user = null;

            var connection = _SQLConnection.GetConnection();
            connection.Open();

            var cmd = Service.StoreProcedureCall
                (sqlConnection: connection, StoreProcedure: "TradeLine.SignIn", Class: login);

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    flag = ExtensionUtility.PasswordDecrypt(login.Password, rdr["Password"].ToString());    
                    if (flag)
                    {
                        user = new User()
                        {
                            Name = rdr["Name"].ToString(),
                            Lastname = rdr["Lastname"].ToString(),
                            Username = rdr["Username"].ToString(),
                            Email = rdr["Email"].ToString(),
                            Identification = rdr["Identification"].ToString(),
                            ImageURL = rdr["ImageURL"].ToString(),
                            Rol = rdr["Rol"].ToString()
                        };
                    }
                }
            }

            connection.Close();

            return user;
        }

        public string SignUp(User user)
        {
            string Response = null;
            var connection = _SQLConnection.GetConnection();
            connection.Open();

            user.Password = user.Password.PasswordEncrypt();

            var cmd = Service.StoreProcedureCall
                (sqlConnection: connection, StoreProcedure: "TradeLine.SignUp", Class: user);

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    Response = rdr["RESPONSE"].ToString();
                }
            }

            connection.Close();
            return Response;
        }
    }
}
