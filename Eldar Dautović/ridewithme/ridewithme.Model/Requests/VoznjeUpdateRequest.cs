using System;
using System.Collections.Generic;

namespace ridewithme.Model.Requests
{
    public class VoznjeUpdateRequest
    {
        public int? GradOdId { get; set; }
        public int? GradDoId { get; set; }
        public string? Napomena { get; set; }
        public double? Cijena { get; set; }
        public int? DogadjajId { get; set; }

        public int? VozacId { get; set; }

        public DateTime? DatumVrijemePocetka { get; set; }

    }
}
