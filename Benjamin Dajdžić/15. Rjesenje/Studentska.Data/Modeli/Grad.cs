namespace Studentska.Data.Entiteti
{
    public class Grad { 
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }


        // FK -> Foreign key
        public int DrzavaId { get; set; } // 1 
        public Drzava Drzava { get; set; } // nav. prop -> 1 Bosna i Herceogina	BIH	1



        public bool Aktivan { get; set; }


        public override string ToString()
        {
            return Naziv;
        }



    }
}
