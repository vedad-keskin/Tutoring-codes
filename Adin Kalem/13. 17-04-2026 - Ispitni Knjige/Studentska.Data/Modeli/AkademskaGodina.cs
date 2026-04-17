namespace Studentska.Data.Entiteti
{
    public class AkademskaGodina
    {

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }
        public bool Aktivan { get; set; }


        // friend ostream& operator << ... 
        public override string ToString()
        {
            // COUT << Naziv;
            return Naziv;
        }
        
    }
}
