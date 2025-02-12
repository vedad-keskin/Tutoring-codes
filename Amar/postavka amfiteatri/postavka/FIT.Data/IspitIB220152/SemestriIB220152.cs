using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB220152
{
    public class SemestriIB220152
    {
        public int Id { get; set; }
        public string Oznaka { get; set; }
        public string Opis { get; set; }
        public int Aktivan { get; set; }
        public override string ToString()
        {
            return $"{Oznaka}";
        }
    }
}
