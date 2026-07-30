using System.Drawing;

namespace Studentska.Data.Entiteti
{


    public class Student
    {
        public int Id { get; set; }
        public string Indeks { get; set; }
        public string Lozinka { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int Semestar { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int SpolId{ get; set; }
        public Spol Spol { get; set; }
        public int GradId { get; set; }
        public Grad Grad { get; set; }
        public bool Aktivan { get; set; }
        public byte[] Slika { get; set; }
       
    }    
}
