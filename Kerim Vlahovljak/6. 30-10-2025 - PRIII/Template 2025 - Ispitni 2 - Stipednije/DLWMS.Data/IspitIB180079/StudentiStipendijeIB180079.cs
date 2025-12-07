using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.Data.IspitIB180079
{
    public class StudentiStipendijeIB180079
    {
        public int Id { get; set; }
        // FK

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int StipendijaGodinaId { get; set; }
        public StipendijeGodineIB180079 StipendijaGodina { get; set; }

        public string StudentInfo => $"({Student.BrojIndeksa}) {Student.Ime} {Student.Prezime}";

        public string GodinaInfo => StipendijaGodina?.Godina ?? "2025";
        public string StipendijaInfo => StipendijaGodina?.Stipendija?.Naziv ?? "";
        public int IznosInfo => StipendijaGodina?.Iznos ?? 0;

        public int Ukupno => StipendijaGodina.Godina == DateTime.Now.Year.ToString() ? StipendijaGodina.Iznos * DateTime.Now.Month : StipendijaGodina.Iznos * 12;

    }
}
