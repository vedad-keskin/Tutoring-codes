using FIT.Data.ispitIB230030;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;

namespace FIT.WinForms.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private ProstorijeIB230030? odabranaProstorija;
        DLWMSDbContext db = new DLWMSDbContext();
        public frmIzvjestaji()
        {
            InitializeComponent();
        }

        public frmIzvjestaji(ProstorijeIB230030? odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {
            IsprintajReport();

            reportViewer1.RefreshReport();
        }

        private void IsprintajReport()
        {

            var prisustva = db.PrisustvoIB230030
              .Include(x=> x.Student)
              .Include(x=> x.Nastava.Predmet)
              .Where(x => x.Nastava.ProstorijaID == odabranaProstorija.Id)
              .ToList();


            var tblPrisustva = new dsIzvjestajIB180079.dsPrisustvaDataTable();


            for (int i = 0; i < prisustva.Count(); i++)
            {

                var Red = tblPrisustva.NewdsPrisustvaRow();

                Red.Rb = (i + 1).ToString();
                //Red.Rb = $"{i + 1}";
                Red.Predmet = prisustva[i].Nastava.Predmet.Naziv;
                Red.Vrijeme = prisustva[i].Nastava.Vrijeme;
                Red.BrojIndeksa = prisustva[i].Student.Indeks;
                Red.ImePrezime = $"{prisustva[i].Student.Ime} {prisustva[i].Student.Prezime}";


                tblPrisustva.Rows.Add(Red);


            }

            var rds = new ReportDataSource();

            rds.Value = tblPrisustva;
            rds.Name = "dsPrisustvo";

            reportViewer1.LocalReport.DataSources.Add(rds);


            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("broj", prisustva.Count().ToString()));
            rpc.Add(new ReportParameter("prostorija", odabranaProstorija.Naziv   ));


            reportViewer1.LocalReport.SetParameters(rpc);



        }
    }
}
