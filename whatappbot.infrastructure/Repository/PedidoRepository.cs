
using Microsoft.EntityFrameworkCore;
using whatappbot.domain.Entity;
using whatappbot.domain.Repository;
using whatappbot.infrastructure.Context;

namespace whatappbot.infrastructure.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly AppDbContext _context;

        public PedidoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pedido> CrearAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido?> ObtenerPorIdAsync(int id)
        {
            return await _context.Pedidos
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Pedido>> ObtenerPorNumeroWhatsAppAsync(string numeroWhatsApp)
        {
            return await _context.Pedidos
                .Include(p => p.Items)
                .Where(p => p.NumeroWhatsApp == numeroWhatsApp)
                .OrderByDescending(p => p.FechaCreacion)
                .ToListAsync();
        }

        public async Task<IEnumerable<Pedido>> ObtenerTodosAsync()
        {
            return await _context.Pedidos
                .Include(p => p.Items)
                .OrderByDescending(p => p.FechaCreacion)
                .ToListAsync();
        }

        public async Task ActualizarAsync(Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
        }
    }
}

