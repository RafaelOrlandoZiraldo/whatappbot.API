using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.domain.Entity;

namespace whatappbot.domain.Repository
{
    public interface IClienteRepository
    {
        Task<Cliente> CrearAsync(Cliente cliente);
        Task ActualizarAsync(Cliente cliente);
        Task<Cliente?> ObtenerPorIdAsync(int id);
        Task<Cliente?> ObtenerPorNumeroWhatsAppAsync(string numeroWhatsApp);
        Task<IEnumerable<Cliente>> ObtenerTodosAsync();
    }
}
