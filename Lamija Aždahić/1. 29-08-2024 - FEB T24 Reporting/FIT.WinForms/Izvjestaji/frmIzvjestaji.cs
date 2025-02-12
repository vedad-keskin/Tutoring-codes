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

        public frmIzvjestaji()
        {
            InitializeComponent();
        }

        public frmIzvjestaji(ProstorijeIB180079? odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {
            var svaPrisustva = db.PrisustvoIB180079
               .Include(x=> x.Nastava).ThenInclude(x=> x.Predmet)
               .Include(x=> x.Student)
               .Where(x => x.Nastava.ProstorijaId == odabranaProstorija.Id)
               .ToList();

            // Rb   Grad   Drzava   Aktivan
            var tblPrisustva = new dsIzvjestajIB180079.dsPrisustvaDataTable();

            for (int i = 0; i < svaPrisustva.Count(); i++)
            {

                var Red = tblPrisustva.NewdsPrisustvaRow();

                Red.Rb = (i + 1).ToString();
                Red.Predmet = svaPrisustva[i].Nastava.Predmet.Naziv;
                Red.Vrijeme = svaPrisustva[i].Nastava.Vrijeme;
                Red.BrojIndeksa = svaPrisustva[i].Student.Indeks;
                Red.ImePrezime = $"{svaPrisustva[i].Student.Ime} {svaPrisustva[i].Student.Prezime}";

                tblPrisustva.Rows.Add(Red);
            }

            var rds = new ReportDataSource();

            rds.Value = tblPrisustva;
            rds.Name = "dsPrisustva";

            reportViewer1.LocalReport.DataSources.Add(rds);


            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("Broj", svaPrisustva.Count().ToString()));
            rpc.Add(new ReportParameter("Prostorija", odabranaProstorija.Naziv));

            reportViewer1.LocalReport.SetParameters(rpc);






            reportViewer1.RefreshReport();
        }
    }
}
