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

        public int StudentId { get; set; } // 3 
        public Student Student { get; set; } // 3	IB180079	test	Vedad	Keskin	6	1998-12-12 14:12:05.858335	2	1	BLOB	1

        // calc. par
        public string StudentInfo => $"({Student?.Indeks ?? "N/A"}) {Student?.Ime ?? "N/A"} {Student?.Prezime ?? "N/A"}";



        public int KnjigaId { get; set; }
        public KnjigeIB180079 Knjiga { get; set; }

        public string KnjigaInfo => $"{Knjiga?.Naziv ?? "N/A"} ({Knjiga?.Autor ?? "N/A"})";




        public DateTime DatumIznajmljivanja { get; set; }
        public DateTime? DatumVracanja { get; set; }

        //public bool VracenaInfo => DatumVracanja == null ? false : true;

        public bool Vracena { get; set; }



    }
}
