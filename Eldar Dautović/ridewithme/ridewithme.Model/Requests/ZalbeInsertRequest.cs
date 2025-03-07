using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class ZalbeInsertRequest
    {
        public string Naslov { get; set; }

        public string Sadrzaj { get; set; }

        public int VrstaZalbeId { get; set; }

        public int KorisnikId { get; set; }

    }
}