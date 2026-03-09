using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatappbot.domain.Entity
{
    public class PedidoItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Pedido))]
        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; }

        [Required]
        [MaxLength(100)]
        public string NombreProducto { get; set; } = string.Empty;

        public int Cantidad { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioUnitario { get; set; }

        [NotMapped]
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
