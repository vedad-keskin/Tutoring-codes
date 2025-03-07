using System;
using System.Collections.Generic;
using System.Text;

namespace ridewithme.Model.Requests
{
    public class VoznjeBookRequest
    {
        public int? KlijentId { get; set; }

        public string? Kod { get; set; }

        public string Payment_Id { get; set; }
    }
}
