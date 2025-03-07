using System;
using System.Collections.Generic;


namespace ridewithme.Model.Models
{
    public class Reklame
    {
        public int Id { get; set; }

        public string NazivKlijenta { get; set; }

        public string NazivKampanje { get; set; }

        public string SadrzajKampanje { get; set; }

        public byte[]? Slika { get; set; }

        public Korisnici Korisnik { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public DateTime DatumKreiranja { get; set; }

    }

}

