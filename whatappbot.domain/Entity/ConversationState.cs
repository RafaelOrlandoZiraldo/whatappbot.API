using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.aplication.Enum;

namespace whatappbot.domain.Entity
{
    public class ConversationState
    {
        public int Id { get; set; }

        // Para saber en qué paso del flujo está el usuario
        public ChatState EstadoActual { get; set; } = ChatState.Inicio;

        // Si necesitás guardar información temporal del flujo
        public string? DatosTemporales { get; set; }

        // Último mensaje recibido
        public DateTime UltimaInteraccion { get; set; } = DateTime.UtcNow;

        // Relación con el usuario
        public int ChatUserId { get; set; }
        public ChatUser ChatUser { get; set; } = null!;
    }
}
