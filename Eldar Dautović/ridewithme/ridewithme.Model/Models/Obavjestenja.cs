using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Models
{
    public class Obavjestenja
    {
        public int Id { get; set; }

        public string StateMachine { get; set; }

        public string Naslov { get; set; }

        public string Podnaslov { get; set; }

        public string Opis { get; set; }

        public DateTime DatumKreiranja { get; set; }

        public DateTime DatumIzmjene { get; set; }

        public DateTime? DatumZavrsetka { get; set; }

        public Korisnici Korisnik { get; set; }
    }
}
