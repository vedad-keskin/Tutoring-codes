using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Database
{
    public class Zalbe
    {
        public int Id { get; set; }

        public string Naslov { get; set; }

        public string Sadrzaj { get; set; }

        public string? OdgovorNaZalbu { get; set; }

        public DateTime DatumIzmjene { get; set; }

        public DateTime? DatumPreuzimanja { get; set; }

        public DateTime DatumKreiranja { get; set; }

        public string StateMachine { get; set; }

        public int VrstaZalbeId { get; set; }

        public virtual VrstaZalbe VrstaZalbe { get; set; }

        public int? AdministratorId { get; set; }

        public virtual Korisnici? Administrator { get; set; }

        public int KorisnikId { get; set; }

        public virtual Korisnici Korisnik { get; set; }
    }
}
