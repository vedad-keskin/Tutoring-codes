using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class ReklameInsertRequest
    {
        public string NazivKlijenta { get; set; }

        public string NazivKampanje { get; set; }

        public string SadrzajKampanje { get; set; }

        public byte[]? Slika { get; set; }

        public int KorisnikId { get; set; }

    }
}
