using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.SearchObject
{
    public class FAQSearchObject : BaseSearchObject
    {
        public string? OrderBy { get; set; }
        public string? PitanjeGTE { get; set; }

        public bool? IsKorisnikIncluded { get; set; }
    }
}
