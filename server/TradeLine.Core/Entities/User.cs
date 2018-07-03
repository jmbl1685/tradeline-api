using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TradeLine.Entities
{
    public class User
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public User()
        {

        }

        [JsonProperty("_id")]
        [Required]
        public string UserCode { get; set; }

        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("lastname")]
        [Required]
        public string Lastname { get; set; }

        [JsonProperty("username")]
        [Required]
        public string Username { get; set; }

        [JsonProperty("password")]
        [Required]
        public string Password { get; set; }

        [JsonProperty("email")]
        [DataType(DataType.EmailAddress), EmailAddress, Required]
        public string Email { get; set; }

        [JsonProperty("imageurl")]
        [Required]
        public string ImageURL { get; set; }

    }
}
