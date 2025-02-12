using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB210166
{
    public class PolozeniPredmetiIB210166
    {
        public int Id { get; set; }


        public int StudentId { get; set; }
        public Student Student { get; set; }


        public int PredmetId { get; set; }
        public PredmetiIB210166 Predmet { get; set; }


        public int Ocjena { get; set; }
        public DateTime DatumPolaganja { get; set; }
        public string Napomena { get; set; }



    }
}
