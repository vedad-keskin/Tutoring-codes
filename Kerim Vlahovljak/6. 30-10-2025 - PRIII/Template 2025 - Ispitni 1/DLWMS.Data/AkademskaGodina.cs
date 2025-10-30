namespace DLWMS.Data
{
    public class AkademskaGodina
    {
        // PK --> static 
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public bool Aktivan { get; set; }


        // friend ostream& operator << ...
        public override string ToString()
        {
            return Naziv;
        }


    }
}