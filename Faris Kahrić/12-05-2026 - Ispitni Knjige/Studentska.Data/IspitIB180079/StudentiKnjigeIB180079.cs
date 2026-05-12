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
        public Student Student { get; set; } // 1	IB250001	zj)UHb4087	Jasmin	Azemovic	0	2025-12-23 14:12:05.858335	1	1	BLOB	1

        public int KnjigaId { get; set; }
        public KnjigeIB180079 Knjiga { get; set; }

        public DateTime DatumIznajmljivanja { get; set; }
        public DateTime? DatumVracanja { get; set; }
        public bool Vracena { get; set; }

    }
}
