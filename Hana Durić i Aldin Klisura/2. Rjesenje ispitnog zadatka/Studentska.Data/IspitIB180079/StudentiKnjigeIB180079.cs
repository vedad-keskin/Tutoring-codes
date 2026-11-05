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

        // FK
        public int StudentId { get; set; } // 1
        public Student Student { get; set; } // 1	IB250001	zj)UHb4087	Jasmin	Azemovic	0	2025-12-23 14:12:05.858335	1	1	BLOB

        public string StudentInfo => $"({Student?.Indeks ?? "N/A"}) {Student?.Ime ?? "N/A"} {Student?.Prezime ?? "N/A"}";


        public int KnjigaId { get; set; }
        public KnjigeIB180079 Knjiga { get; set; }

        public string KnjigaInfo => $"{Knjiga?.Naziv ?? "N/A"} ({Knjiga?.Autor ?? "N/A"})";


        public DateTime DatumIznajmljivanja { get; set; }
        public DateTime? DatumVracanja { get; set; }



        // calc col. 
        public bool VracenaInfo => DatumVracanja == null ? false : true;
        public bool Vracena { get; set; }

        public bool AktivanInfo => Student?.Aktivan ?? false;




    }
}
