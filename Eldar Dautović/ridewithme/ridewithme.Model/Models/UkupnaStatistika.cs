using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Models
{
    public class UkupnaStatistika
    {
        public List<MjesecnaStatistika>? MjesecnaStatistika { get; set; }

        public Statistika? Statistika { get; set; }
    }
}
