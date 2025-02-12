using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB180079
{
    public class GradoviIB180079
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool Status { get; set; }
        public int DrzavaId { get; set; } // 1
        public DrzaveIB180079 Drzava { get; set; } // BiH aktivna 

        public override string ToString()
        {
            return Naziv;
        }

    }
}
