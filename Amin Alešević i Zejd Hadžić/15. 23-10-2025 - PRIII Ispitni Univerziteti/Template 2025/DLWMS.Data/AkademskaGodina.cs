namespace DLWMS.Data
{
    public class AkademskaGodina
    {
        public int Id { get; set; } // PK 
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public bool Aktivan { get; set; }


        // friend ostream& ... 
        public override string ToString()
        {
            // COUT << Naziv ;
            return Naziv;
        }
    }
}