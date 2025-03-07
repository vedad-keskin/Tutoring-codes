using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.SearchObject
{
    public class ZalbeSearchObject : BaseSearchObject
    {
        public string? NaslovGTE { get; set; }

        public DateTime? DatumPreuzimanja { get; set; }

        public int? KorisnikId { get; set; }

        public string? VrstaZalbeGTE { get; set; }

        public bool? IsKorisnikIncluded { get; set; }

        public bool? IsAdministratorIncluded { get; set; }

        public bool? IsVrstaZalbeIncluded { get; set; }

        public string? KorisnickoImeAdministratorGTE { get; set; }
        public string? KorisnickoImeKorisnikGTE { get; set; }

        public string? OrderBy { get; set; }

        public string? Status { get; set; }
    }
}
