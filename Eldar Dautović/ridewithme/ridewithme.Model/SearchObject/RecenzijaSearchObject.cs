using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.SearchObject
{
    public class RecenzijaSearchObject : BaseSearchObject
    {
        public int? VoznjaId { get; set; }

        public string? KorisnikGTE { get; set; }

        public int? KorisnikId { get; set; }

        public string? OrderBy { get; set; }
    }
}
