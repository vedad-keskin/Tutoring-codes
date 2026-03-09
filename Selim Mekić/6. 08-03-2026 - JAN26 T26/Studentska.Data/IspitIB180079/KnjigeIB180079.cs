using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Studentska.Data.IspitIB180079
{
    public class KnjigeIB180079
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Autor { get; set; }
        public int BrojPrimjeraka { get; set; }
        public byte[] Slika { get; set; }

        public override string ToString()
        {
            return $"{Naziv} ({Autor})";
        }
    }
}
