using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Database
{
    public partial class Kuponi
    {
        public int Id { get; set; }

        public string Kod { get; set; }

        public string Naziv { get; set; }

        public DateTime DatumPocetka { get; set; }

        public int BrojIskoristivosti { get; set; }

        public string StateMachine { get; set; }

        public double Popust { get; set; }

        public int KorisnikId { get; set; }

        public virtual Korisnici Korisnik { get; set; }

        public DateTime DatumIzmjene { get; set; }
    }
}
