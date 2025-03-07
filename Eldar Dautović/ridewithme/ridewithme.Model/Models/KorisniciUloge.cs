using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Model.Models
{
    public partial class KorisniciUloge
    {
        public int Id { get; set; }
        public DateTime DatumIzmjene { get; set; }
        public virtual Uloge Uloga { get; set; } = null!;

    }
}

