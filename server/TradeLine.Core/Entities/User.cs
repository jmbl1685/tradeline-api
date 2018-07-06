using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace TradeLine.Core
{
    public class User
    {

        public User()
        {
            this.UserCode = ExtensionUtility.GenerateUUID();
        }

        [JsonProperty("_id")]
        public string UserCode { get; private set; }

        [JsonProperty("name")]
        [Required]
        public string Name { get; set; }

        [JsonProperty("lastname")]
        [Required]
        public string Lastname { get; set; }

        [JsonProperty("identification")]
        [Required]
        public string Identification { get; set; }

        [JsonProperty("username")]
        [Required]
        public string Username { get; set; }

        [JsonProperty("password")]
        [Required, StringLength(255, MinimumLength = 5)]
        public string Password { get; set; }

        [JsonProperty("email")]
        [Required, RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "The Email field is not a valid e-mail address.")]
        public string Email { get; set; }

        [JsonProperty("imageurl")]
        [Required]
        public string ImageURL { get; set; }

        [JsonProperty("rol")]
        [Required]
        public string Rol { get; set; }
    }
}
