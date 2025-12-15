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
        public Grad Grad { get; set; } // Mostar MO ... 

        public int SpolId { get; set; } // 1
        public Spol Spol { get; set; } // Muski true ... 


        public byte[] Slika { get; set; }

        public bool Aktivan { get; set; }

        public string StudentInfo => $"({BrojIndeksa}) {Ime} {Prezime}";
        public string DrzavaInfo => Grad?.Drzava?.Naziv ?? "N/A";
        public string GradInfo => Grad?.Naziv ?? "N/A";
        public string SpolInfo => Spol?.Naziv ?? "N/A";


        public override string ToString()
        {
            // Denis Music (IB180079) .. 
            return $"({BrojIndeksa}) {Ime} {Prezime}";
        }


    }
}