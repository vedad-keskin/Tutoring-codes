using System;
using System.Collections.Generic;

namespace ridewithme.Model.Requests
{
    public class KuponiInsertRequest
    {
        public int KorisnikId { get; set; }
        public string Kod { get; set; }
        public string Naziv { get; set; }
        public DateTime DatumPocetka { get; set; }
        public int BrojIskoristivosti { get; set; }
        public double Popust { get; set; }
    }
}
