using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace TradeLine
{
    public static class Service
    {

        #region StoreProcedureCall 
        public static SqlCommand StoreProcedureCall(SqlConnection sqlConnection, string StoreProcedure, object Class)
        {

            SqlCommand cmd = new SqlCommand(StoreProcedure, sqlConnection);
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
        #endregion

    }
}
