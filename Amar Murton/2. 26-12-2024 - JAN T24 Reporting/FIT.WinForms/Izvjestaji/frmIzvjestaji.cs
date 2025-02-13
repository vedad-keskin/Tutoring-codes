using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;

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

            var gradoviDrzave = db.GradoviIB180079
                .Include(x=> x.Drzava)
                .Where(x=> x.DrzavaId == odabranaDrzava.Id)
             .ToList();


            var tblGradovi = new dsIzvjestajIB180079.dsGradoviDataTable();

            for (int i = 0; i < gradoviDrzave.Count(); i++)
            {
                var Red = tblGradovi.NewdsGradoviRow();

                Red.Rb = (i + 1).ToString();

                Red.Grad = gradoviDrzave[i].Naziv;
                Red.Drzava = gradoviDrzave[i].Drzava.Naziv;

                Red.Aktivan = gradoviDrzave[i].Status == true ? "DA" : "NE";


                tblGradovi.Rows.Add(Red);

            }

            var rds = new ReportDataSource();

            rds.Name = "dsGradovi";
            rds.Value = tblGradovi;

            reportViewer1.LocalReport.DataSources.Add(rds);


            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("broj", gradoviDrzave.Count().ToString()));
       

            reportViewer1.LocalReport.SetParameters(rpc);





            reportViewer1.RefreshReport();
        }
    }
}
