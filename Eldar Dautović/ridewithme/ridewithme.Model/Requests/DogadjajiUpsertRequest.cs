using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class DogadjajiUpsertRequest
    {
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public DateTime DatumPocetka { get; set; }

        public DateTime DatumZavrsetka { get; set; }
    }
}
