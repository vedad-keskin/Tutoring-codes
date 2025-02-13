using FIT.Data.IspitIB230030;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace FIT.WinForms.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private DrzaveIB230030? odabranaDrzava;
        DLWMSDbContext db = new DLWMSDbContext();

        public frmIzvjestaji(DrzaveIB230030? odabranaDrzava)
        {
            InitializeComponent();
            this.odabranaDrzava = odabranaDrzava;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            PrintajReport();

            reportViewer1.RefreshReport();
        }

        private void PrintajReport()
        {

            var gradovi = db.GradoviIB230030
                .Include(x=> x.Drzava)
                .Where(x=> x.DrzavaID == odabranaDrzava.Id)
                .ToList();


            var tblGradovi = new dsIzvjestajIB180079.dsGradoviDataTable();


            for (int i = 0; i < gradovi.Count(); i++)
            {

                var Red = tblGradovi.NewdsGradoviRow();

                Red.Rb = (i + 1).ToString();
                //Red.Rb = $"{i + 1}";
                Red.Grad = gradovi[i].Naziv;

                Red.Drzava = gradovi[i].Drzava.Naziv;

                Red.Aktivan = gradovi[i].Status ? "DA" : "NE";

                tblGradovi.Rows.Add(Red);


            }

            var rds = new ReportDataSource();

            rds.Value = tblGradovi;
            rds.Name = "dsGradovi";

            reportViewer1.LocalReport.DataSources.Add(rds);


            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("broj", gradovi.Count().ToString()));


            reportViewer1.LocalReport.SetParameters(rpc);



        }
    }
}
