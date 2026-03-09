using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.domain.Entity;

namespace whatappbot.domain.Repository
{
    public interface IPedidoRepository
    {
        Task<Pedido> CrearAsync(Pedido pedido);
        Task<Pedido?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Pedido>> ObtenerPorNumeroWhatsAppAsync(string numeroWhatsApp);
        Task<IEnumerable<Pedido>> ObtenerTodosAsync();
        Task ActualizarAsync(Pedido pedido);
        Task EliminarAsync(int id);
    }
}
