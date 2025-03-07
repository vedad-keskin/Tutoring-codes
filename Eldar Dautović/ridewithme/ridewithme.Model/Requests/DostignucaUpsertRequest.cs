using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class DostignucaUpsertRequest
    {
        public string Naziv { get; set; }

        public string Opis { get; set; }

        public byte[] Slika { get; set; }
    }
}
