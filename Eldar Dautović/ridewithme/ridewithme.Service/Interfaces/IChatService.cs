using ridewithme.Model.Models;
using ridewithme.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Interfaces
{
    public interface IChatService
    {
        public ChatInsertRequest Send(ChatInsertRequest request);

        public List<ChatMessage> Conversation(int recieverId, int senderId);


    }
}
