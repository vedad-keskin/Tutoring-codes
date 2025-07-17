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

        // FK ..
        public int ProstorijaId { get; set; } // 1
        // Amfiteatar 1 - AMF1 - [Logo] 35  ... 
        public ProstorijeIB180079 Prostorija { get; set; }

        public int PredmetId { get; set; }
        public Predmet Predmet { get; set; }

        public string Vrijeme { get; set; }
        public string Dan { get; set; }
        public string Oznaka { get; set; }

    }
}
