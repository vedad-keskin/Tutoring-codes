using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB180079
{
    public class PolozeniPredmetiIB180079
    {
        public int Id { get; set; }
        public int StudentId { get; set; } // 1 
        public Student Student { get; set; }
        public int PredmetId { get; set; } // 1
        public PredmetiIB180079 Predmet { get; set; }
        public int Ocjena { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public string Napomena { get; set; }

        public string Indeks => Student.Indeks;
        public bool Aktivan => Student.Aktivan;




    }
}
