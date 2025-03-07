using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class RecenzijaUpsertRequest
    {
        public int Ocjena { get; set; }
        public string? Komentar { get; set; }

        public int KorisnikId { get; set; }

        public int VoznjaId { get; set; }
    }
}
