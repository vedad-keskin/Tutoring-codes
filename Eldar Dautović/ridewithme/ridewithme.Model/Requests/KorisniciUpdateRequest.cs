using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class KorisniciUpdateRequest
    {
        public string? Ime { get; set; } = null!;

        public string? Prezime { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public string? Lozinka { get; set; }

        public string? LozinkaPotvrda { get; set; }
        public byte[]? Slika { get; set; }

        public int? UlogaId { get; set; }


    }

}
