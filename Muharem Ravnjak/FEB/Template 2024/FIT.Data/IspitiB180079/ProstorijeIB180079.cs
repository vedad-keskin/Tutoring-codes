using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitiB180079
{
    public class ProstorijeIB180079
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }
        public byte[] Logo { get; set; }
        public int Kapacitet { get; set; }



        // calculated parametar

        [NotMapped]
        public int Broj { get; set; }


        public override string ToString()
        {
            return Naziv;
        }


    }
}
