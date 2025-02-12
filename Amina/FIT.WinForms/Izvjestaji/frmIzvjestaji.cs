using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;

namespace FIT.WinForms.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private ProstorijeIB180079? odabranaPostorija;
        DLWMSDbContext db = new DLWMSDbContext();


        public frmIzvjestaji(ProstorijeIB180079? odabranaPostorija)
        {
            InitializeComponent();
            this.odabranaPostorija = odabranaPostorija;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            var odabranaPrisustva = db.PrisustvoIB180079
                .Include(x => x.Nastava).ThenInclude(x => x.Predmet)
                .Include(x => x.Student)
                .Where(x => x.Nastava.ProstorijaId == odabranaPostorija.Id).ToList();


            var tblPrisustva = new dsIzvjestaj.dsNastaveDataTable(); // ovo je tabela koja ima pohranjene kolone


            for (int i = 0; i < odabranaPrisustva.Count(); i++)
            {

                var Red = tblPrisustva.NewdsNastaveRow();

                Red.Rb = (i + 1).ToString();
                Red.Predmet = odabranaPrisustva[i].Nastava.Predmet.Naziv;
                Red.Vrijeme = odabranaPrisustva[i].Nastava.Vrijeme;
                Red.BrojIndeksa = odabranaPrisustva[i].Student.Indeks;
                Red.ImePrezime = $"{odabranaPrisustva[i].Student.Ime}  {odabranaPrisustva[i].Student.Prezime}" ;


                tblPrisustva.Rows.Add(Red);



            }

            var rds = new ReportDataSource();
            rds.Value = tblPrisustva;
            rds.Name = "dsNastave";

            reportViewer1.LocalReport.DataSources.Add(rds);


            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("prostorija", odabranaPostorija.Naziv));
            rpc.Add(new ReportParameter("broj", odabranaPrisustva.Count().ToString()));


            reportViewer1.LocalReport.SetParameters(rpc);



            reportViewer1.RefreshReport();
        }
    }
}
