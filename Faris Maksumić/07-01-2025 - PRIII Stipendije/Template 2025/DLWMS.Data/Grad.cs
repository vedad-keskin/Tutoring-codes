namespace DLWMS.Data
{
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }

        // FK 
        public int DrzavaId { get; set; } // 1 .. 2
        public Drzava Drzava { get; set; } // 1	Bosna i Hercegovina	BIH	1




        public bool Aktivan { get; set; }


        public override string ToString()
        {
            return Naziv;
        }

    }
}
