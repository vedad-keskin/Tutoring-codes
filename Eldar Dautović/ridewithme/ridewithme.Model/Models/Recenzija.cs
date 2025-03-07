using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Models
{
    public class Recenzija
    {
        public int Id { get; set; }
        public int Ocjena { get; set; }
        public string? Komentar { get; set; }
        public virtual Korisnici Korisnik { get; set; }
        public virtual Voznje Voznja { get; set; }
        public DateTime DatumKreiranja { get; set; }
    }
}
