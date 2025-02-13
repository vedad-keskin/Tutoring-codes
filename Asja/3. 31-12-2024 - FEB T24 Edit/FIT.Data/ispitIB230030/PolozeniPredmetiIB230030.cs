using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.ispitIB230030
{
    public class PolozeniPredmetiIB230030
    {
        public int Id { get; set; }
        public int StudentID { get; set; }
        public Student Student { get; set; }
        public int PredmetID { get; set; }
        public PredmetiIB230030 Predmet { get; set; }

        public int ocjena { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public string Napomena { get; set; }
    }
}
