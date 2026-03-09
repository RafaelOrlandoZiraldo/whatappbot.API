
using whatappbot.aplication.Enum;
using whatappbot.aplication.Interface;
using whatappbot.domain.Entity;
using whatappbot.domain.Repository;

namespace whatappbot.aplication.Services
{
    public class ManageStateService: IManageStateService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        public ManageStateService(IUserRepository userRepository, IEmailService emailService)
        {
            _userRepository = userRepository;
            _emailService = emailService;
        }

        public async Task<string> ManageState( string input,string from)
        {
            var session = await _userRepository.GetByWhatsAppIdAsync(from);
            if (session == null)
            {
                session = new ChatUser
                {
                    WhatsAppId  = from,
                    FechaCreacion = DateTime.UtcNow,
                    ConversationState = new ConversationState()
                    {
                        EstadoActual =ChatState.Inicio,
                        UltimaInteraccion = DateTime.UtcNow
                    }
                };
                await _userRepository.AddAsync(session);
                await _userRepository.SaveChangesAsync();
                
            }

            switch (session.ConversationState!.EstadoActual)
            {
                case ChatState.Inicio:
                    session.ConversationState!.EstadoActual = ChatState.Categoria;
                    await _userRepository.SaveChangesAsync();
                    return "Bienvenido, gracias por comunicarse con nosotros. Soy el asistente virtual y estoy aquí para ayudarle. ¿En qué aspecto de nuestro servicio desea que lo asesoremos?";

                case ChatState.TipoCliente:
                    session.ConversationState!.EstadoActual = ChatState.Producto;
                    await _userRepository.SaveChangesAsync();
                    return "¿Podría indicarnos si se comunica en calidad de cliente mayorista o minorista?"

                case ChatState.Producto:
                    session.ConversationState!.EstadoActual = ChatState.ConfirmacionPedido;
                    await _userRepository.SaveChangesAsync();
                    return $"✅ Agregué {input} a tu pedido. ¿Querés agregar algo más? (sí/no)";

                case ChatState.ConfirmacionPedido:
                    if (input.ToLower() == "sí" || input.ToLower() == "si")
                    {
                        session.ConversationState!.EstadoActual = ChatState.Categoria;
                        await _userRepository.SaveChangesAsync();
                        return "Perfecto 🙌 ¿Qué categoría querés ver?\n1️⃣ Pizzas\n2️⃣ Hamburguesas\n3️⃣ Bebidas";
                    }
                    else
                    {
                        session.ConversationState!.EstadoActual = ChatState.DatosEntrega;
                        await _userRepository.SaveChangesAsync();
                        return "📍 Pasame tu dirección de entrega.";
                    }

                case ChatState.DatosEntrega :
                    
                    session.ConversationState!.EstadoActual = ChatState.ConfirmacionFinal;
                    await _userRepository.SaveChangesAsync();
                    return $"Perfecto. Tu pedido es:.\nDirección:¿Confirmás el pedido? (sí/no)";

                case ChatState.ConfirmacionFinal:
                    if (input.ToLower() == "sí" || input.ToLower() == "si")
                    {
                        session.ConversationState!.EstadoActual = ChatState.Inicio; // Reiniciamos para próximos pedidos

                        await _userRepository.SaveChangesAsync();
                        await ProcesarMensaje("Confirmado el pedido");
                        return "🎉 Pedido confirmado. Te llegará en 40 minutos. ¡Gracias!";
                    }
                    else
                    {
                        session.ConversationState!.EstadoActual = ChatState.Inicio;
                        await _userRepository.SaveChangesAsync();
                        return "❌ Pedido cancelado. Si querés volver a empezar, escribí cualquier cosa.";
                    }
                  
                default:
                    session.ConversationState!.EstadoActual = ChatState.Inicio;
                    await _userRepository.SaveChangesAsync();
                    return "🤖 Algo salió mal. Volvamos a empezar.";
            }
            
        }
        public async Task ProcesarMensaje(string userMessage)
        {
           
                await _emailService.SendEmailAsync(
                    to: "rafazira83@gmail.com",
                    subject: "Hola desde tu chatbot",
                    body: "<h2>Tu chatbot te envió este correo con SendGrid 🚀</h2>"
                );
           
        }
    }
}
