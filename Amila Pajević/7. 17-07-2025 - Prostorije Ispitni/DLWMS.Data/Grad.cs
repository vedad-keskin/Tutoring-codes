namespace DLWMS.Data
{
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }

        // FK -> strani kljuc
        public int DrzavaId { get; set; } // 1
        public Drzava Drzava { get; set; } // Bosna BIH true .. 

        public bool Aktivan { get; set; }

    }
}
