using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class ObavjestenjaInsertRequest
    {
        public string Naslov { get; set; }

        public string Podnaslov { get; set; }

        public string Opis { get; set; }

        public DateTime? DatumZavrsetka { get; set; }

        public int KorisnikId { get; set; }
    }
}
