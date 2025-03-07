using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Models
{
    public class Dogadjaji
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Opis { get; set; }

        public DateTime DatumKreiranja { get; set; }

        public DateTime DatumIzmjene { get; set; }

        public DateTime DatumPocetka { get; set; }

        public DateTime DatumZavrsetka { get; set; }
    }
}
