using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB230030
{
    public class GradoviIB230030
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool Status { get; set; }
        public int DrzavaID { get; set; }
        public DrzaveIB230030 Drzava { get; set; }
        public override string ToString()
        {
            return Naziv;
        }

    }
}
