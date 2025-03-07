using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class GradoviUpsertRequest
    {
        public string Naziv { get; set; } = null!;
        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
