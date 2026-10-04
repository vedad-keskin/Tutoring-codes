namespace Studentska.Data.Entiteti
{
    public class Grad { 
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }


        // FK -> foreign key
        public int DrzavaId { get; set; } // 1 , 2 , 3 .. 
        public Drzava Drzava { get; set; } // nav. prop -> 1 -> Bosna i Her. BS ... 


        public bool Aktivan { get; set; }


        public override string ToString()
        {
            return Naziv;
        }



    }
}
