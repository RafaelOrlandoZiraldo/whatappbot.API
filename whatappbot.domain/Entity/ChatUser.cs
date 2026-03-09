using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatappbot.domain.Entity
{
    public class ChatUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string WhatsAppId { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Nombre { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        // Estado de conversación
        public ConversationState? ConversationState { get; set; }

        // 🔗 Relación muchos a uno: muchos ChatUsers pertenecen a un Cliente
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; } = null!;
    }
}
