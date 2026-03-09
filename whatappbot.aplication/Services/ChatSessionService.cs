using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.aplication.DTO;
using whatappbot.aplication.Interface;

namespace whatappbot.aplication.Services
{
    public class ChatSessionService: IChatSessionService
    {
        private readonly ConcurrentDictionary<string, ChatSessionDto> _sessions = new();
        public ChatSessionService() { }

       

        public ChatSessionDto GetSession(string userId)
        {
            return _sessions.GetOrAdd(userId, new ChatSessionDto { UserId = userId });
        }

     
        public void UpdateSession(ChatSessionDto session)
        {
            _sessions[session.UserId] = session;
        }
    }
}
