using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using FIT.Data.IspitIB230030;

namespace FIT.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string Indeks { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public byte[] Slika { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public bool Aktivan { get; set; }        
        public int SemestarId { get; set; }
        public SemestriIB230030 Semestar { get; set; }
        public int GradID { get; set; }
        public GradoviIB230030 Grad { get; set; }

        public string DrzavaInfo => Grad.Drzava.Naziv ?? "N/A";
        [NotMapped]
        public double Prosjek { get; set; }
        public override string ToString()
        {
            return $"{Indeks} {Ime} {Prezime}";
        }
    }
}
