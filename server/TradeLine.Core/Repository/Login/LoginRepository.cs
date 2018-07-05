using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using TradeLine.Core.Entities;

namespace TradeLine.Core
{
    public class LoginRepository : ILoginRepository
    {

        public void SignIn(Login login)
        {
            throw new NotImplementedException();
        }

        public SqlCommand StoreProcedureCall(SqlConnection sqlConnection, string StoreProcedure, object Class)
        {

            SqlCommand cmd = new SqlCommand("SignUp", sqlConnection);
            cmd.CommandText = StoreProcedure;
            cmd.CommandType = CommandType.StoredProcedure;

            Type type = Class.GetType();

            foreach (PropertyInfo propertyInfo in type.GetProperties())
            {
                var field = propertyInfo.Name;
                var value = type.GetProperty(field).GetValue(Class, null);
                cmd.Parameters.Add(new SqlParameter($"@{field}", value));
            }

            return cmd;
        }

        public object GetPropertyValue(object instance, string strPropertyName)
        {
            Type type = instance.GetType();
            PropertyInfo propertyInfo = type.GetProperty(strPropertyName);
            return propertyInfo.GetValue(instance, null);
        }

        public void SignUp(User user)
        {

            var connection = _SQLConnection.GetConnection();

            connection.Open();

            var cmd = StoreProcedureCall
                (sqlConnection: connection, StoreProcedure: "SignUp", Class: user);

            using (SqlDataReader rdr = cmd.ExecuteReader())
            {

                while (rdr.Read())
                {
                    var x = rdr["Email"];
                }
            }

            connection.Close();

        }
    }
}
