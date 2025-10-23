namespace DLWMS.Data
{
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }

        // FK -> strani kljuc 
        public int DrzavaId { get; set; } // 1/2 .. 
        public Drzava Drzava { get; set; } // BiH true .. 


        public bool Aktivan { get; set; }


        public override string ToString()
        {
            return Naziv;
        }

    }
}
