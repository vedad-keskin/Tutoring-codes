namespace DLWMS.Data
{
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }

        // FK -> STRANI KLJUC. 


        public int DrzavaId { get; set; } // 1 
        public Drzava Drzava { get; set; } // 1	Bosna i Hercegovina	BIH	true



        public bool Aktivan { get; set; }

        public override string ToString()
        {
            return Naziv;
        }


    }
}
