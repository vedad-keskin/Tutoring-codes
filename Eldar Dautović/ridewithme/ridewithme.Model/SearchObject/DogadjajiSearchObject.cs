using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.SearchObject
{
    public class DogadjajiSearchObejct : BaseSearchObject
    {
        public string? NazivGTE { get; set; }
        public string? OpisGTE { get; set; }
        public DateTime? DatumPocetka { get; set; }
        public DateTime? DatumZavrsetka { get; set; }

        public string? OrderBy { get; set; }

    }
}
