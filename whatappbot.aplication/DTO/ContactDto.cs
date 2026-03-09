using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace whatappbot.aplication.DTO
{
    public class ContactDto
    {
        [JsonProperty("profile")]
        public Profile Profile { get; set; }

        [JsonProperty("wa_id")]
        public string WaId { get; set; }
    }
}
