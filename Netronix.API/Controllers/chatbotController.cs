using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Netronix.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class chatbotController : ControllerBase
    {
        [HttpPost]
        [Route("create-session")]
        public IActionResult CreateChatbotSession()
        {
            // This is a placeholder for the actual implementation
            return Ok(new { message = "Chatbot session created" });
        }
        [HttpPost]
        [Route("sendMessage")]
        public IActionResult SendMessageToChatbot()
        {
            // This is a placeholder for the actual implementation
            return Ok(new { message = "Message sent to chatbot" });
        }
        [HttpDelete]
        public IActionResult EndChatbotSession() {
            return Ok(new { message = "Session ended" });
        }
    }
}
