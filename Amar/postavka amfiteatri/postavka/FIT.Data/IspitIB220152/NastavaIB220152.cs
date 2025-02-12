using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB220152
{
    public class NastavaIB220152
    {
        public int Id { get; set; }
        public int ProstorijeId { get; set; }
        public ProstorijeIB220152 Prostorije { get; set; }
        public int PredmetId { get; set; }
        public PredmetiIB220152 Predmet { get; set; }
        public string Vrijeme { get; set; }
        public string Dan { get; set; }
        public string Oznaka { get; set; }


        public override string ToString()
        {
            return $"{Predmet} u {Dan} @ {Vrijeme}";
        }


    }
}
