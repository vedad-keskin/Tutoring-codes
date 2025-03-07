using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Models
{
    public class Voznje
    {
        public int Id { get; set; }
        public string StateMachine { get; set; }
        public DateTime? DatumVrijemePocetka { get; set; }
        public DateTime? DatumVrijemeZavrsetka { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public int? Ocjena { get; set; }
        public double Cijena { get; set; }
        public string? Napomena { get; set; }
        public virtual Gradovi GradOd { get; set; }
        public virtual Gradovi GradDo { get; set; }
        public virtual Korisnici Vozac { get; set; }
        public virtual Korisnici? Klijent { get; set; }
        public virtual Kuponi? Kupon { get; set; }
        public virtual Dogadjaji? Dogadjaj { get; set; }
    }
}
