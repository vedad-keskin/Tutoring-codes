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

        public string StudentInfo => $"({Student?.Indeks ?? "N/A"}) {Student?.Ime ?? "N/A"} {Student?.Prezime ?? "N/A"}";

        public bool AktivanInfo => Student?.Aktivan ?? false;


        public int KnjigaId { get; set; }
        public KnjigeIB180079 Knjiga { get; set; }

        public string KnjigaInfo => $"{Knjiga?.Naziv ?? "N/A"} ({Knjiga?.Autor ?? "N/A"})";


        public DateTime DatumIznajmljivanja { get; set; }
        public DateTime? DatumVracanja { get; set; }

        public bool Vracena { get; set; }

        //public bool VracenaInfo => DatumVracanja == null ? false : true;


    }
}
