using Studentska.Data.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentska.Data.IspitIB180079
{
    public class StudentiKnjigeIB180079
    {
        public int Id { get; set; }


        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int KnjigaId { get; set; }
        public KnjigeIB180079 Knjiga { get; set; }

        public DateTime DatumIznajmljivanja { get; set; }
        public DateTime? DatumVracanja { get; set; } // nullable

        public bool Vracena { get; set; }


        public string StudentInfo => Student == null ? "N/A" : $"({Student.Indeks}) {Student.Ime} {Student.Prezime}";
        public string KnjigaInfo => Knjiga == null ? "N/A" : $"{Knjiga.Naziv} ({Knjiga.Autor})";

        public string StudentIndeksInfo => Student?.Indeks ?? "N/A";

    }
}
