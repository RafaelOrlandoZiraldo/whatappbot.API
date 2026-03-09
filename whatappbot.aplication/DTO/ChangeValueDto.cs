using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace whatappbot.aplication.DTO
{
    public class ChangeValueDto
    {
        [JsonPropertyName("messaging_product")]
        public string MessagingProduct { get; set; }

        [JsonPropertyName("metadata")]
        public MetadataDto Metadata { get; set; }

        [JsonPropertyName("contacts")]
        public List<ContactDto> Contacts { get; set; }

        [JsonPropertyName("messages")]
        public List<MessageDto> Messages { get; set; }
    }
}
