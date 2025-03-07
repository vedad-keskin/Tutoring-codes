using System;
using System.Collections.Generic;

namespace ridewithme.Model.Requests
{
    public class VoznjeInsertRequest
    {
        public int VozacId { get; set; }
        public double Cijena { get; set; }
        public int GradOdId { get; set; }
        public int GradDoId { get; set; }
        public string? Napomena { get; set; }
        public int? DogadjajId { get; set; }
        public DateTime? DatumVrijemePocetka { get; set; }

    }
}
