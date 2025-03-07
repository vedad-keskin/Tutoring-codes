using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Models
{
    public class PoslovniIzvjestaj
    {
        public int Godina { get; set; }
        public int BrojAdministratora { get; set; }

        public int BrojVoznji { get; set; }

        public int BrojKorisnika { get; set; }

        public int BrojKreiranihKupona { get; set; }

        public int BrojIskoristenihKupona { get; set; }

        public double PrihodiVozaca { get; set; }
    }
}
