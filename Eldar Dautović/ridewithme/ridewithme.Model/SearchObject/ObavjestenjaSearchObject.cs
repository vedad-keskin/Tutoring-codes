using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.SearchObject
{
    public class ObavjestenjaSearchObject : BaseSearchObject
    {
        public bool? IsCompletedIncluded { get; set; }

        public string? OrderBy { get; set; }

        public string? Status { get; set; }

        public DateTime? DatumOdGTE { get; set; }

        public DateTime? DatumDoGTE { get; set; }

    }
}
