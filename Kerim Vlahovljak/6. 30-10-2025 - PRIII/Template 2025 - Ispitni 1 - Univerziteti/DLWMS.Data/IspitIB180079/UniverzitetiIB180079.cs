using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IspitIB180079
{
    public class UniverzitetiIB180079
    {

        public int Id { get; set; }
        public string Naziv { get; set; }
        
        // FK
        public int DrzavaId { get; set; } // 1
        public Drzava Drzava { get; set; } // Bosna ... 

        public override string ToString()
        {
            return Naziv;
        }


    }
}
