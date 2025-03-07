using System;
using System.Collections.Generic;


namespace ridewithme.Model.Models
{
    public class Zalbe
    {
        public int Id { get; set; }

        public string Naslov { get; set; }

        public string Sadrzaj { get; set; }

        public string? OdgovorNaZalbu { get; set; }

        public DateTime DatumIzmjene { get; set; }

        public DateTime? DatumPreuzimanja { get; set; }

        public DateTime DatumKreiranja { get; set; }

        public string StateMachine { get; set; }

        public virtual VrstaZalbe VrstaZalbe { get; set; }

        public virtual Korisnici? Administrator { get; set; }

        public virtual Korisnici Korisnik { get; set; }
    }

}

