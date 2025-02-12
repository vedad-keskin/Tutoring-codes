using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB210166
{
    public class NastavaIB210166
    {
        public int Id {  get; set; }
        public int ProstorijeId { get; set; } // 1


        // ovo se mora includati u pretragu
        public ProstorijeIB210166 Prostorije { get; set; } // AMF1 
        public int PredmetId { get; set; }

        // ovo se mora includati u pretragu
        public PredmetiIB210166 Predmet { get; set; }

        public string Vrijeme { get; set; }
        public string Dan { get; set; }
        public string Oznaka { get; set; }


        public override string ToString()
        {
            return $"{Predmet} - u {Dan} @ {Vrijeme}";
        }

    }
}
