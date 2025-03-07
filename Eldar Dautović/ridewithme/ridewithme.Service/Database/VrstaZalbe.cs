using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Database
{
    public class VrstaZalbe
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public int KorisnikId { get; set; }

        public virtual Korisnici Korisnik { get; set; }

        public DateTime DatumIzmjene { get; set; }
    }
}
