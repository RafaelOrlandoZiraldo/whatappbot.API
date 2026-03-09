using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.domain.Entity;

namespace whatappbot.domain.Repository
{
    public interface IUserRepository
    {
        Task<ChatUser?> GetByWhatsAppIdAsync(string waId);
        Task AddAsync(ChatUser user);
        Task SaveChangesAsync();
    }
}
