using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Database
{
    public class Recenzija
    {
        public int Id { get; set; }

        public int KorisnikId { get; set; }

        public int VoznjaId { get; set; }

        public int Ocjena { get; set; }

        public string? Komentar { get; set; }

        public virtual Korisnici Korisnik { get; set; }

        public virtual Voznje Voznja { get; set; }

        public DateTime DatumKreiranja { get; set; }
    }
}
