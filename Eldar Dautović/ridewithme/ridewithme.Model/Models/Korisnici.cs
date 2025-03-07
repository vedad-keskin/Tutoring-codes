using System;
using System.Collections.Generic;


namespace ridewithme.Model.Models
{
    public partial class Korisnici
    {
        public int Id { get; set; }

        public string Ime { get; set; } = null!;

        public string Prezime { get; set; } = null!;

        public string KorisnickoIme { get; set; } = null!;

        public byte[]? Slika { get; set; }

        public string Email { get; set; } = null!;
        public virtual ICollection<KorisniciUloge> KorisniciUloge { get; set; }

        public virtual ICollection<KorisniciDostignuca> KorisniciDostignuca { get; set; }

        public DateTime DatumKreiranja { get; set; }

    }
}
