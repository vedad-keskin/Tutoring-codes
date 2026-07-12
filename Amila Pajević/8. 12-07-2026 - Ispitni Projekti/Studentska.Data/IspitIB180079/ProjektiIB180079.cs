using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Studentska.Data.IspitIB180079
{
    public class ProjektiIB180079
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public byte[] Logo { get; set; }
        public DateTime RokZavrsetka { get; set; }
        public int MaxBrojStudenata { get; set; }
        public bool Aktivan { get; set; }
        public string? Napomena { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

    }
}
