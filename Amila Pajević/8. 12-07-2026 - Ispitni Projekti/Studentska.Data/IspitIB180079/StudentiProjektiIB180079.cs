using Studentska.Data.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Studentska.Data.IspitIB180079
{
    public class StudentiProjektiIB180079
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ProjekatId { get; set; }
        public ProjektiIB180079 Projekat { get; set; }
        public DateTime DatumPrijave { get; set; }
        public string Status { get; set; }
        public DateTime? DatumPromjene { get; set; }
        public bool Arhivirano { get; set; }

        public string ArhiviranoInfo => Arhivirano == true ? "Arhivirana" : "Aktivna";

        public DateTime RokZavrsetkaInfo => Projekat?.RokZavrsetka ?? DateTime.Now;


    }
}
