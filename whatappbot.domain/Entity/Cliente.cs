using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.domain.Enum;

namespace whatappbot.domain.Entity
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string NumeroWhatsApp { get; set; } = string.Empty; // Puede ser el principal o representativo

        [MaxLength(100)]
        public string? Nombre { get; set; }

        public TipoCliente TipoCliente { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        // 🔗 Relación uno a muchos: un cliente puede tener varios ChatUsers
        public ICollection<ChatUser> ChatUsers { get; set; } = new List<ChatUser>();

        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
