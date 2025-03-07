using System;
using System.Collections.Generic;


namespace ridewithme.Model.Models
{
    public partial class Kuponi
    {
        public int Id { get; set; }

        public string Kod { get; set; }

        public string Naziv { get; set; }

        public DateTime DatumPocetka { get; set; }

        public int BrojIskoristivosti { get; set; }

        public string StateMachine { get; set; }

        public double Popust { get; set; }

        public virtual Korisnici Korisnik { get; set; }

        public DateTime DatumIzmjene { get; set; }

    }
}
