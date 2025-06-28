using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IspitIB180079
{
    public class StudentiStipendijeIB180079
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int StipendijaGodinaId { get; set; }
        public StipendijeGodineIB180079 StipendijaGodina { get; set; }
        public string GodinaInfo => StipendijaGodina?.Godina ?? "N/A";
        public string StipendijaInfo => StipendijaGodina?.Stipendija?.Naziv ?? "N/A";
        public string IznosInfo => StipendijaGodina?.Iznos.ToString() ?? "N/A";
        public int UkupnoInfo => StipendijaGodina.Godina == DateTime.Now.Year.ToString() ? StipendijaGodina.Iznos * DateTime.Now.Month : StipendijaGodina.Iznos * 12;

    }
}
