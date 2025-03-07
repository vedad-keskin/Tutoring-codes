using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Database
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
