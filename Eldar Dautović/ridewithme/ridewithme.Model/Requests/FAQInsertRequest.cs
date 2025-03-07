using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class FAQInsertRequest
    {
        public string Pitanje { get; set; }

        public string Odgovor { get; set; }

        public int KorisnikId { get; set; }
    }
}
