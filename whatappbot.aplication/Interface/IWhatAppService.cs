using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatappbot.aplication.Interface
{
    public interface IWhatAppService
    {
        Task SendMessageAsync(string to, string message);
        Task SendMessageViaTwilioAsync(string to, string message);
    }
}
