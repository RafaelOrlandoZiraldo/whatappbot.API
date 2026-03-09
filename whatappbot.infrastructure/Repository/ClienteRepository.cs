using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.domain.Entity;
using whatappbot.domain.Repository;
using whatappbot.infrastructure.Context;

namespace whatappbot.infrastructure.Repository
{
    public class ClienteRepository
    {
          private readonly AppDbContext _context;

            public ClienteRepository(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Cliente> CrearAsync(Cliente cliente)
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }

            public async Task ActualizarAsync(Cliente cliente)
            {
                _context.Clientes.Update(cliente);
                await _context.SaveChangesAsync();
            }

            public async Task<Cliente?> ObtenerPorIdAsync(int id)
            {
                return await _context.Clientes
                    .Include(c => c.Pedidos)
                    .ThenInclude(p => p.Items)
                    .FirstOrDefaultAsync(c => c.Id == id);
            }

            public async Task<Cliente?> ObtenerPorNumeroWhatsAppAsync(string numeroWhatsApp)
            {
                return await _context.Clientes
                    .Include(c => c.Pedidos)
                    .ThenInclude(p => p.Items)
                    .FirstOrDefaultAsync(c => c.NumeroWhatsApp == numeroWhatsApp);
            }

            public async Task<IEnumerable<Cliente>> ObtenerTodosAsync()
            {
                return await _context.Clientes
                    .Include(c => c.Pedidos)
                    .OrderByDescending(c => c.FechaRegistro)
                    .ToListAsync();
            }
        }
  
}
