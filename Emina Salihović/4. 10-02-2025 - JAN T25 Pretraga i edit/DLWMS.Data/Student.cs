using System.ComponentModel.DataAnnotations.Schema;

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
        public int GradId { get; set; }

        public Grad Grad { get; set; } // .. override tost.. 
        public int SpolId { get; set; }
        public Spol Spol { get; set; }

        public byte[] Slika { get; set; }
        public bool Aktivan { get; set; }


        // CUSTOM Paramteri
        // ako su nam dostupni
        // => .. i radimo ih odma 


        public string StudentInfo => $"({BrojIndeksa}) {Ime} {Prezime}" ?? "N/A";

        public string DrzavaInfo => Grad?.Drzava?.Naziv ?? "N/A";

        //public string GradInfo => Grad?.Naziv ?? "N/A";
        //public string SpolInfo => Spol?.Naziv ?? "N/A";


        // ako nam nisu dostupni paramteri koji se traze 
        // radimo NotMapped i popunjavamo ga preko for petlje u formi


        public override string ToString()
        {
            return $"{Ime} {Prezime}";
        }

    }
}