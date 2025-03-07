using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.SearchObject
{
    public class ReklameSearchObject : BaseSearchObject
    {
       public string? NazivKlijentaGTE { get; set; }

       public string? NazivKampanjeGTE { get; set; }

       public DateTime? DatumKreiranja { get; set; }
       public DateTime? DatumIzmjene { get; set; }

       public int? KorisnikId { get; set; }

       public bool? IsKorisniciIncluded { get; set; }

    }
}
