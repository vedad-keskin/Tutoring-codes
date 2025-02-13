using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.ispitIB230030
{
    public class NastavaIB230030
    {
        public int Id { get; set; }
        public int ProstorijaID { get; set; }
        public ProstorijeIB230030 Prostorija { get; set; }
        public int PredmetID { get; set; }
        public PredmetiIB230030 Predmet { get; set; }
        public string Vrijeme { get; set; }
        public string Dan { get; set; }
        public string Oznaka { get; set; }

    }
}
