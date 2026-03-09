
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using whatappbot.domain.Entity;

namespace whatappbot.infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ChatUser> ChatUsers { get; set; }
        public DbSet<ConversationState> ConversationStates { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItem> PedidoItems { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatUser>()
                .HasIndex(u => u.WhatsAppId)
                .IsUnique();

            modelBuilder.Entity<ChatUser>()
                .HasOne(u => u.ConversationState)
                .WithOne(c => c.ChatUser)
                .HasForeignKey<ConversationState>(c => c.ChatUserId);

            modelBuilder.Entity<ConversationState>()
                .Property(c => c.EstadoActual)
                .HasConversion<string>();

            modelBuilder.Entity<Cliente>()
                .Property(p => p.TipoCliente)
                .HasConversion<string>();

            modelBuilder.Entity<Cliente>()
               .HasMany(c => c.ChatUsers)
               .WithOne(u => u.Cliente)
               .HasForeignKey(u => u.ClienteId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
