using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace FIT.WinForms.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private DrzaveIB180079 odabranaDrzava;
        DLWMSDbContext db = new DLWMSDbContext();


        public frmIzvjestaji(DrzaveIB180079 odabranaDrzava)
        {
            InitializeComponent();
            this.odabranaDrzava = odabranaDrzava;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            var gradoviOdabraneDrzave = db.GradoviIB180079
                .Include(x=> x.Drzava)
                .Where(x=> x.DrzavaId == odabranaDrzava.Id)
                .ToList();

            var tblGradovi = new dsIzvjestajIB180079.dsGradoviDataTable();

            for (int i = 0; i < gradoviOdabraneDrzave.Count(); i++)
            {

                var Red = tblGradovi.NewdsGradoviRow();

                Red.Rb = (i + 1).ToString();
                Red.Grad = gradoviOdabraneDrzave[i].Naziv;
                Red.Drzava = gradoviOdabraneDrzave[i].Drzava.Naziv;
                Red.Aktivan = gradoviOdabraneDrzave[i].Status == true ? "DA" : "NE";

                tblGradovi.Rows.Add(Red);


            }

            var rds = new ReportDataSource();

            rds.Value = tblGradovi;
            rds.Name = "dsGradovi";


            reportViewer1.LocalReport.DataSources.Add(rds);


            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("Broj", gradoviOdabraneDrzave.Count().ToString()));


            reportViewer1.LocalReport.SetParameters(rpc);

            reportViewer1.RefreshReport();
        }
    }
}
