using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.aplication.DTO;

namespace whatappbot.aplication.Interface
{
    public interface IManageStateService
    {
        Task<string> ManageState(string input, string from);
    }
}
