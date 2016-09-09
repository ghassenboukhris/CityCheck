using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityCheck
{
    class User
    {
        [JsonProperty("idUser")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string Name1 { get; set; }

        [JsonProperty("lastName")]
        public string Name2 { get; set; }

        [JsonProperty("email")]
        public string EmaiAddress { get; set; }
        [JsonProperty("password")]
        public string Passwords { get; set; }
    }
}
