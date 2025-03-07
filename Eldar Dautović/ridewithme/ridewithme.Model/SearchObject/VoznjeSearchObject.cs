using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.SearchObject
{
    public class VoznjeSearchObject : BaseSearchObject
    {
        public int? VoznjaId { get; set; }
        public int? VozacId { get; set; }
        public int? KlijentId { get; set; }
        public int? GradOdId { get; set; }
        public int? GradDoId { get; set; }
        public int? CijenaDo { get; set; }
        public DateTime? DatumVrijemePocetka { get; set; }

        public DateTime? DatumVrijemeZavrsetka { get; set; }

        public bool? IsVoznjaActivated { get; set; }

        public bool? IsKorisniciIncluded { get; set; }
        public bool? IsGradoviIncluded { get; set; }

        public string? OrderBy { get; set; }

        public string? Status { get; set; }


        public string? KorisnickoImeVozacGTE { get; set; }

        public string? KorisnickoImeKlijentGTE { get; set; }

    }
}
