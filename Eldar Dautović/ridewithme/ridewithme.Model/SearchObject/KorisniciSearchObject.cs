using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.SearchObject
{
    public class KorisniciSearchObject : BaseSearchObject
    {
        public string? ImeGTE { get; set; }
        public string? PrezimeGTE { get; set; }
        public string? KorisnickoIme { get; set; }
        public string? Email { get; set; }
        public bool? IsKorisniciIncluded { get; set; }
        public bool? IsDostignucaIncluded { get; set; }
        public string? OrderBy { get; set; }
    }
}
