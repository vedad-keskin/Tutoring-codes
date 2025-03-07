using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ridewithme.Model.Models
{
    public partial class Gradovi
    {
        public int Id { get; set; }

        public string Naziv { get; set; } = null!;

        public double Longitude { get; set; }

        public double Latitude { get; set; }

    }
}
