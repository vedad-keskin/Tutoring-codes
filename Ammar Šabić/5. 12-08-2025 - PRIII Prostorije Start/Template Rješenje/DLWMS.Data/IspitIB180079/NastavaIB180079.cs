using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IspitIB180079
{
    public class NastavaIB180079
    {
        public int Id { get; set; }
        public int ProstorijaId { get; set; }
        public ProstorijeIB180079 Prostorija { get; set; }

        public int PredmetId { get; set; } // 1 
        public Predmet Predmet { get; set; } // 1 Programiranje 7 ... 

        public string Vrijeme { get; set; }
        public string Dan { get; set; }
        public string Oznaka { get; set; }


    }
}
