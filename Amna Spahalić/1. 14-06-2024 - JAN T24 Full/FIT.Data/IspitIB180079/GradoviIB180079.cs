using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

        // ovi parametri se dodaju preko komande include
        public DrzaveIB180079 Drzava { get; set; } // Bosna i Herc Status Zastave


        public override string ToString()
        {
            return Naziv;
        }
    }
}
