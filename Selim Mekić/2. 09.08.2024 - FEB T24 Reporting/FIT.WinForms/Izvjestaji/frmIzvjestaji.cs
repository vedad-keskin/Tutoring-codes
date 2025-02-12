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

            var prisustvaProstorije = db.PrisustvoIB180079
               .Include(x=> x.Nastava).ThenInclude(x=> x.Predmet)
               .Include(x=> x.Student)
               .Where(x => x.Nastava.ProstorijaId == odabranaProstorija.Id)
               .ToList();

            var tblPrisustva = new dsIzvjestajIB180079.dsPrisustvaDataTable();


            for (int i = 0; i < prisustvaProstorije.Count(); i++)
            {

                var Red = tblPrisustva.NewdsPrisustvaRow();

                Red.Rb = (i + 1).ToString();
                Red.Predmet = prisustvaProstorije[i].Nastava.Predmet.ToString();
                Red.Vrijeme = prisustvaProstorije[i].Nastava.Vrijeme;
                Red.BrojIndeksa = prisustvaProstorije[i].Student.Indeks;
                Red.ImePrezime = $"{prisustvaProstorije[i].Student.Ime} {prisustvaProstorije[i].Student.Prezime}";




                tblPrisustva.Rows.Add(Red);

            }

            var rds = new ReportDataSource();

            rds.Value = tblPrisustva;
            rds.Name = "dsPrisustvo";

            reportViewer1.LocalReport.DataSources.Add(rds);


            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("Broj", prisustvaProstorije.Count().ToString()));
            rpc.Add(new ReportParameter("Prostorija", odabranaProstorija.ToString()));

            reportViewer1.LocalReport.SetParameters(rpc);




            reportViewer1.RefreshReport();
        }
    }
}
