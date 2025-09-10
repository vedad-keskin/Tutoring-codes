namespace DLWMS.Data
{
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }

        // FK
        public int DrzavaId { get; set; } // 1 2 3 ...
        public Drzava Drzava { get; set; } // 1 BiH ... 



        public bool Aktivan { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

    }
}
