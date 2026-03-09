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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ChatUser user)
        {
            await _context.ChatUsers.AddAsync(user);
        }

        public async Task<ChatUser?> GetByWhatsAppIdAsync(string waId)
        {
            return await _context.ChatUsers
            .Include(u => u.ConversationState)
            .FirstOrDefaultAsync(u => u.WhatsAppId == waId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
