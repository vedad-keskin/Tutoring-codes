using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB220152
{
    public class ProstorijeIB220152
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }
        public byte[] Logo { get; set; }
        public int Kapacitet { get; set; }
        [NotMapped]
        public int Broj { get; set; }

        public override string ToString()
        {
            return $"{Naziv}";
        }

    }
}
