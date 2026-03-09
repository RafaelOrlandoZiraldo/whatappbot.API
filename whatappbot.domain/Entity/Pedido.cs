using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.domain.Enum;

namespace whatappbot.domain.Entity
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        public Cliente Cliente { get; set; }

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        [Required]
        public EstadoPedido Estado { get; set; } = EstadoPedido.Pendiente;

        public ICollection<PedidoItem> Items { get; set; } = new List<PedidoItem>();

        [Column(TypeName = "decimal(10,2)")]
        public decimal Total { get; set; }
    }
}
