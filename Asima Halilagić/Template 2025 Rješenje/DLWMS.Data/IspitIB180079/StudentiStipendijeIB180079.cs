using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IspitIB180079
{
    public class StudentiStipendijeIB180079
    {
        public int Id { get; set; } // 1
        public int StudentId { get; set; } // 1
        public Student Student { get; set; }
        public int StipendijaGodinaId { get; set; } // 2
        public StipendijeGodineIB180079 StipendijaGodina { get; set; }

        public string GodinaInfo => StipendijaGodina?.Godina ?? "N/A";

        public string StipendijaInfo => StipendijaGodina?.Stipendija?.Naziv ?? "N/A";

        public int IznosInfo => StipendijaGodina?.Iznos ?? 0;

        public int UkupnoInfo => DateTime.Now.Year.ToString() == StipendijaGodina.Godina ? StipendijaGodina.Iznos * DateTime.Now.Month : StipendijaGodina.Iznos * 12;


    }
}
