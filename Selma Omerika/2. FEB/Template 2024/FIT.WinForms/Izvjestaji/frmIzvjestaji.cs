using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;

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
            var prisustvaOdabraneProstorije = db.PrisustvoIB180079
                .Include(x=> x.Nastava).ThenInclude(x=> x.Predmet)
                .Include(x=> x.Student)
                .Where(x => x.Nastava.ProstorijaId == odabranaProstorija.Id)
                .ToList();

            var tblPrisustva = new dsIzvjestajIB180079.dsPrisustvaDataTable();

            for (int i = 0; i < prisustvaOdabraneProstorije.Count(); i++)
            {

                var Red = tblPrisustva.NewdsPrisustvaRow();

                Red.Rb = (i + 1).ToString();
                Red.Predmet = prisustvaOdabraneProstorije[i].Nastava.Predmet.Naziv;
                Red.Vrijeme = prisustvaOdabraneProstorije[i].Nastava.Vrijeme;
                Red.BrojIndeksa = prisustvaOdabraneProstorije[i].Student.Indeks;
                Red.ImePrezime = $"{prisustvaOdabraneProstorije[i].Student.Ime} {prisustvaOdabraneProstorije[i].Student.Prezime}";

                tblPrisustva.Rows.Add(Red);


            }

            var rds = new ReportDataSource();

            rds.Value = tblPrisustva;
            rds.Name = "dsPrisustva";


            reportViewer1.LocalReport.DataSources.Add(rds);


            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("Broj", prisustvaOdabraneProstorije.Count().ToString()));
            rpc.Add(new ReportParameter("Naziv", odabranaProstorija.ToString()));


            reportViewer1.LocalReport.SetParameters(rpc);


            reportViewer1.RefreshReport();
        }
    }
}
