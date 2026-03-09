using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace whatappbot.aplication.DTO
{
    public class TextDto
    {
        [JsonPropertyName("body")]
        public string Body { get; set; }
    }
}
