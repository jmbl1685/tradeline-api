using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TradeLine.Core.DBConnection.Credentials
{
    public static class Credentials
    {

        public static string path = Environment.CurrentDirectory.Replace("TradeLine.API", "TradeLine.Core");
        public static string currentPath = $"{path}\\Credentials";
        public static ItemsCredential json = JsonConvert.DeserializeObject<ItemsCredential>(File.ReadAllText($"{currentPath}\\Credentials.json"));

        public static string SQLCredential()
        {
            return json.SqlServer;
        }

        public static string MongoDBCredential()
        {
            return json.MongoDB;
        }

    }

    public class ItemsCredential
    {
        public string SqlServer { get; set; }
        public string MongoDB { get; set; }
    }

}
