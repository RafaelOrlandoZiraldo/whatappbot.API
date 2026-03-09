using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using whatappbot.aplication.Enum;

namespace whatappbot.aplication.DTO
{
    public class ChatSessionDto
    {
        public string UserId { get; set; }
        public ChatState Estado { get; set; } = ChatState.Inicio;
        public List<string> Pedido { get; set; }
        public string Direccion { get; set; }
        public string FormaPago { get; set; }
    }
}
