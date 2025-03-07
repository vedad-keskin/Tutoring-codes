using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Database
{
    public class KorisniciDostignuca
    {
        public int Id { get; set; }

        public int KorisnikId { get; set; } 
        public Korisnici Korisnik { get; set; }

        public int DostignuceId { get; set; }
        public Dostignuca Dostignuce { get; set; }

        public DateTime DatumKreiranja { get; set; }
    }
}
