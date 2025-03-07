using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Database
{
    public class ChatMessage
    {
        public int Id { get; set; }

        public int SenderId { get; set; }

        public int RecieverId { get; set; }

        public string Message { get; set; }

        public Korisnici Sender { get; set; }

        public Korisnici Reciever { get; set; }

        public DateTime DatumKreiranja { get; set; }
    }
}
