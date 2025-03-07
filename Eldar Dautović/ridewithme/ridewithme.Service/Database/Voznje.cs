using System;
using System.Collections.Generic;

namespace ridewithme.Service.Database;

public partial class Voznje
{
    public int Id { get; set; }
    public string StateMachine { get; set; }
    public DateTime? DatumVrijemePocetka { get; set; }
    public DateTime? DatumVrijemeZavrsetka { get; set; }
    public DateTime DatumKreiranja { get; set; }
    public string? Napomena { get; set; }
    public double Cijena { get; set; }
    public int GradOdId { get; set; }
    public int GradDoId { get; set; }
    public virtual Gradovi GradOd { get; set; }
    public virtual Gradovi GradDo { get; set; }
    public int VozacId { get; set; }
    public int? KlijentId { get; set; }
    public int? KuponId { get; set; }
    public int? DogadjajId { get; set; }
    public virtual Korisnici Vozac { get; set; }
    public virtual Korisnici? Klijent { get; set; }
    public virtual Kuponi? Kupon { get; set; }
    public virtual Dogadjaji? Dogadjaj { get; set; }
}
