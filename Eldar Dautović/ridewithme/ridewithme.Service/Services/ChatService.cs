using MapsterMapper;
using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using ridewithme.Service.Database;
using ridewithme.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace ridewithme.Service.Services
{
    public class ChatService : IChatService
    {
        private IEmailService _emailService;
        private RidewithmeContext _context;
        public IMapper Mapper { get; set; }

        public ChatService(IEmailService emailService, RidewithmeContext context, IMapper mapper) {
            _emailService = emailService;
            _context = context;
            Mapper = mapper;
        }
        public ChatInsertRequest Send(ChatInsertRequest request)
        {
            var newMessage = new Database.ChatMessage()
            {
                SenderId = request.SenderId,
                RecieverId = request.RecieverId,
                Message = request.Message,
                DatumKreiranja = DateTime.Now
            };

            _context.Add(newMessage);

            _context.SaveChanges();

            _emailService.SendingMessage(request.Message, request.SenderId, request.RecieverId);
         
            return request;
        }

        public List<Model.Models.ChatMessage> Conversation(int recieverId, int senderId)
        {
            List<Model.Models.ChatMessage> result = new List<Model.Models.ChatMessage>();

            var conversation = _context.ChatMessages
                .Include(x => x.Sender)
                .Include(x => x.Reciever)
                .Where(x =>
                    (x.RecieverId == recieverId && x.SenderId == senderId) ||
                    (x.RecieverId == senderId && x.SenderId == recieverId)) // Dodan obrnut smjer
                .OrderBy(x => x.DatumKreiranja)
                .ToList();

            result = Mapper.Map(conversation, result);

            return result;
        }

    }
}
