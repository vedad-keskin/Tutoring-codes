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

        // FK
        public int GradId { get; set; } // 1
        public Grad Grad { get; set; } // 1	Sarajevo	SA	1	true


        public int SpolId { get; set; } // 1
        public Spol Spol { get; set; } // 1	Muški	true



        public byte[] Slika { get; set; }
        public bool Aktivan { get; set; }

        public override string ToString()
        {
            // Vedad Keskin (IB180079)
            return $"{Ime} {Prezime} ({BrojIndeksa})";
        }


    }
}