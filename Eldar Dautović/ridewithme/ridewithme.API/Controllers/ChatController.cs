using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Service.Interfaces;

namespace ridewithme.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        protected IChatService _service;
        public ChatController(IChatService service)
        {
            _service = service;
        }


        [HttpPost("send")]
        public ChatInsertRequest Send(ChatInsertRequest request)
        {
            return _service.Send(request);
        }

        [HttpGet("{recieverId}/conversation/{senderId}")]
        public List<ChatMessage> Conversation(int recieverId, int senderId)
        {
            return _service.Conversation(recieverId, senderId);
        }
    }
}
