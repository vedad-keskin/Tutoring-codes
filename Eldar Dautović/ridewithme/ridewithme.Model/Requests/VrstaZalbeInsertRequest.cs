using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class VrstaZalbeInsertRequest
    {
        public int KorisnikId { get; set; }
        public string Naziv { get; set; } = null!;
    }
}
