using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using whatappbot.aplication.DTO;
using whatappbot.aplication.Enum;
using whatappbot.aplication.Interface;
using whatappbot.aplication.Services;

namespace whatappbot.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WhatsAppWebhookController : Controller
    {
       
        private readonly IChatSessionService _chatsessionService;
        private readonly IWhatAppService _whatsAppService;
        private readonly IManageStateService _manageStateService;

        public WhatsAppWebhookController( IWhatAppService whatsAppService, IManageStateService manageStateService, IChatSessionService chatsessionService)
        {
            _chatsessionService = chatsessionService;
            _whatsAppService = whatsAppService;
            _manageStateService = manageStateService;
        }
        
        [HttpGet]
        public IActionResult Verify(
        [FromQuery(Name = "hub.mode")] string mode,
        [FromQuery(Name = "hub.challenge")] string challenge,
        [FromQuery(Name = "hub.verify_token")] string verifyToken)
        {
            if (mode == "subscribe" && verifyToken == "miverifytoken") // debe coincidir
            {
                return Ok(challenge); // 200 + texto del challenge
            }

            return Forbid();
        }
        [HttpPost()]
        public async Task<IActionResult> ReceiveMessage([FromForm] string from, [FromForm] string Body)
        {
            try
           {
              
               var message = Body;
                
                string respuesta =await _manageStateService.ManageState( message, from);
                await _whatsAppService.SendMessageViaTwilioAsync(from, respuesta);

                return Ok();
            }
            catch
            {
                return Ok(); // WhatsApp exige 200 OK aunque no proceses
            }
        }
    
    }

}
