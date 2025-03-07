using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Service.Database
{
    public class Payments
    {
        public int Id { get; set; }

        public string Payment_Id { get; set; }

        public int VoznjaId { get; set; }

        public int KorisnikId { get; set; }
    }
}
