using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB180079
{
    public class NastavaIB180079
    {
        public int Id { get; set; } // dobit
        public int ProstorijaId { get; set; } // dobit
        public ProstorijeIB180079 Prostorija { get; set; }
        public int PredmetId { get; set; } // dobit
        public PredmetiIB180079 Predmet { get; set; } // include ovo
        public string Vrijeme { get; set; } // dobit
        public string Dan { get; set; } // dobit
        public string Oznaka { get; set; } // dobit

        public override string ToString()
        {
            return $"{Predmet} u {Dan} @ {Vrijeme}";
        }

    }
}
