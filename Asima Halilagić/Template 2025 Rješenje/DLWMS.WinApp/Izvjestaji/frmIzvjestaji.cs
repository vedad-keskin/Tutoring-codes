using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace DLWMS.WinApp.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        DLWMSContext db = new DLWMSContext();
        private StipendijeGodineIB180079? odabranaStipendijaGodina;

        //public frmIzvjestaji()
        //{
        //    InitializeComponent();            
        //}

        public frmIzvjestaji(StipendijeGodineIB180079? odabranaStipendijaGodina)
        {
            InitializeComponent();
            this.odabranaStipendijaGodina = odabranaStipendijaGodina;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            UcitajReport();


            reportViewer1.RefreshReport(); 
        }

        private void UcitajReport()
        {

            var studentiStipendije = db.StudentiStipendijeIB180079
                .Include(x=> x.StipendijaGodina)
                .Include(x=> x.Student)
                .Where(x=> x.StipendijaGodinaId == odabranaStipendijaGodina.Id)
                .ToList();

            var tblStipStud = new dsDLWMS.dsStudentiStipendijeDataTable();

            for (int i = 0; i < studentiStipendije.Count(); i++)
            {

                var Red = tblStipStud.NewdsStudentiStipendijeRow();

                Red.Rb = (i + 1).ToString();
                Red.Student = studentiStipendije[i]?.Student?.ToString() ?? "N/A";
                Red.Iznos = studentiStipendije[i]?.IznosInfo.ToString() ?? "N/A";
                Red.Ukupno = studentiStipendije[i]?.UkupnoInfo.ToString() ?? "N/A";

                tblStipStud.Rows.Add(Red);

            }

            var rds = new ReportDataSource();

            rds.Value = tblStipStud;
            rds.Name = "dsStudentiStipendije";

            reportViewer1.LocalReport.DataSources.Add(rds);


            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("godina", odabranaStipendijaGodina.Godina ));

            rpc.Add(new ReportParameter("stipendija", odabranaStipendijaGodina.Stipendija.ToString()));

            int SumaIznosa = studentiStipendije.Sum(x => x.UkupnoInfo);

            rpc.Add(new ReportParameter("sumaIznos",SumaIznosa.ToString()));

            reportViewer1.LocalReport.SetParameters(rpc);




        }
    }
}
