using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public Korisnici Sender { get; set; }

        public Korisnici Reciever { get; set; }

        public DateTime DatumKreiranja { get; set; }
    }
}
