using System;
using System.Collections.Generic;

namespace ridewithme.Model.Requests
{
    public class KuponiUpdateRequest
    {
        public string? Kod { get; set; }
        public string? Naziv { get; set; }
        public DateTime? DatumPocetka { get; set; }
        public int? BrojIskoristivosti { get; set; }
        public double? Popust { get; set; }
    }
}
