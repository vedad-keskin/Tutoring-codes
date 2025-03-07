using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Database
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
        public int KorisnikId { get; set; }

        public Korisnici Korisnik { get; set; }

    }
}
