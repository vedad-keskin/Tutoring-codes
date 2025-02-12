using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace FIT.WinForms.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private ProstorijeIB180079? odabranaProstorija;
        DLWMSDbContext db = new DLWMSDbContext();

        public frmIzvjestaji(ProstorijeIB180079? odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            IspintajReport();


            reportViewer1.RefreshReport();
        }

        private void IspintajReport()
        {

            var prisustvaProstorije = db.PrisustvoIB180079
                .Include(x=> x.Nastava.Predmet)
                .Include(x=> x.Student)
                .Where(x=> x.Nastava.ProstorijaId == odabranaProstorija.Id)
                .ToList();

            var tblPrisustva = new dsIzvjestajIB180079.dsPrisustvaDataTable();

            for (int i = 0; i < prisustvaProstorije.Count(); i++)
            {

                var Red = tblPrisustva.NewdsPrisustvaRow();

                Red.Rb = (i + 1).ToString();
                Red.Predmet = prisustvaProstorije[i].Nastava.Predmet.Naziv;
                Red.Vrijeme = prisustvaProstorije[i].Nastava.Vrijeme;
                Red.BrojIndeksa = prisustvaProstorije[i].Student.Indeks;
                Red.ImePrezime = $"{prisustvaProstorije[i].Student.Ime} {prisustvaProstorije[i].Student.Prezime}";

                tblPrisustva.Rows.Add(Red);

            }

            var rds = new ReportDataSource();

            rds.Value = tblPrisustva;
            rds.Name = "dsPrisustva";

            reportViewer1.LocalReport.DataSources.Add(rds);

            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("broj", prisustvaProstorije.Count().ToString()));
            rpc.Add(new ReportParameter("prostorija", odabranaProstorija.Naziv));

            reportViewer1.LocalReport.SetParameters(rpc);

        }
    }
}
