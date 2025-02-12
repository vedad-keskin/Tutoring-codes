using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIT.Data.IspitIB210166
{
    public class ProstorijeIB210166
    {
        public int Id { get; set; }
        public string Naziv {  get; set; }
        public string Oznaka { get; set; }
        public byte[] Logo { get; set; }
        public int Kapacitet { get; set; }


        [NotMapped]
        public int BrojPredmeta { get; set; }

        public override string ToString()
        {
            return Naziv;
        }


    }
}
