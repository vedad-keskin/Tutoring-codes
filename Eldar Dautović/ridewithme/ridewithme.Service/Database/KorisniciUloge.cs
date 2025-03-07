using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Database
{
    public partial class KorisniciUloge
    {
        public int Id { get; set; }

        public int KorisnikId { get; set; }

        public int UlogaId { get; set; }

        public DateTime DatumIzmjene { get; set; }

        public virtual Uloge Uloga { get; set; } = null!;

        public virtual Korisnici Korisnik { get; set; } = null!;

    }
}
