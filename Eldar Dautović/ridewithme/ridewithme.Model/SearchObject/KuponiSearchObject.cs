using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.SearchObject
{
    public class KuponiSearchObject : BaseSearchObject
    {
        public int? KuponId { get; set; }
        public DateTime? DatumPocetka { get; set; }
        public string? KodGTE { get; set; }
        public string? NazivGTE { get; set; }
        public int? BrojIskoristivostiGTE { get; set; }
        public double? PopustGTE { get; set; }

        public string? Status { get; set; }

        public string? OrderBy { get; set; }

    }
}
