using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatappbot.aplication.DTO
{
    public class Profile
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
