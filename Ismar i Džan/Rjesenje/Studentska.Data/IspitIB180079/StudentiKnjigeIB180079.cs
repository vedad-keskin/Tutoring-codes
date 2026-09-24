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

        public int KnjigaId { get; set; }
        public KnjigeIB180079 Knjiga { get; set; }

        public DateTime DatumIznajmljivanja { get; set; }
        public DateTime? DatumVracanja { get; set; }



    }
}
