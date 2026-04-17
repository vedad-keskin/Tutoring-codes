namespace Studentska.Data.Entiteti
{
    public class Grad { 


        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }

        // FK --> strani kljuc 
        public int DrzavaId { get; set; } // podatak se drzi na bazi .. 1 , 2 .. 
        public Drzava Drzava { get; set; } // dodatni prop. -> 1 Bosna i Herceogina	BIH	1



        public bool Aktivan { get; set; }

        public override string ToString()
        {
            return Naziv;
        }

    }
}
