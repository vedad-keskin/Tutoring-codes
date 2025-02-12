using FIT.Data.IspitIB210166;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Net.WebSockets;

namespace FIT.WinForms.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private ProstorijeIB210166? odabranaProstorija;
        DLWMSDbContext db = new DLWMSDbContext();

        public frmIzvjestaji(ProstorijeIB210166? odabranaProstorija)
        {
            InitializeComponent();
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            // StudentId NastavaId Id

            var prisustvaProstorije = db.PrisustvoIB210166
                .Include(x=> x.Nastava).ThenInclude(x=> x.Predmet)
                .Include(x=> x.Student)
                .Where(x => x.Nastava.ProstorijeId == odabranaProstorija.Id)
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
            rds.Name = "dsPrisustvo";

            reportViewer1.LocalReport.DataSources.Add(rds);

            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("Prostorija",odabranaProstorija.Naziv));

            rpc.Add(new ReportParameter("Broj", prisustvaProstorije.Count().ToString()));

            reportViewer1.LocalReport.SetParameters(rpc);

            reportViewer1.RefreshReport();
        }
    }
}
