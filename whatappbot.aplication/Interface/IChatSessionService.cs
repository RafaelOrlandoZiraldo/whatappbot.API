using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.aplication.DTO;

namespace whatappbot.aplication.Interface
{
    public interface IChatSessionService
    {
        void UpdateSession(ChatSessionDto session);
        ChatSessionDto GetSession(string userId);
    }
}
