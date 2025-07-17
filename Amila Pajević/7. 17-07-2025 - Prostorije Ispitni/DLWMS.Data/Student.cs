namespace DLWMS.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Email { get; set; }
        public string BrojIndeksa { get; set; }
        public string Lozinka { get; set; }
        public int GradId { get; set; } // 1
        public Grad Grad { get; set; } // Mostar .. 


        public int SpolId { get; set; } // 1
        public Spol Spol { get; set; } // Muski


        public byte[] Slika { get; set; }
        public bool Aktivan { get; set; }


        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }
    }
}