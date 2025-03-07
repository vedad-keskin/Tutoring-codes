using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class ChatInsertRequest
    {
        public int SenderId { get; set; }

        public int RecieverId { get; set; }

        public string Message { get; set; }
    }
}
