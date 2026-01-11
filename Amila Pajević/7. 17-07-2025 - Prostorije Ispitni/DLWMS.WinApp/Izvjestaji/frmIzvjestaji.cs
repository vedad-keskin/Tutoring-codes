using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace DLWMS.WinApp.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private ProstorijeIB180079? odabranaProstorija;
        DLWMSContext db = new DLWMSContext();

        //public frmIzvjestaji()
        //{
        //    InitializeComponent();            
        //}

        public frmIzvjestaji(ProstorijeIB180079? odabranaProstorija)
        {
            InitializeComponent();            
            this.odabranaProstorija = odabranaProstorija;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            UcitajIzvjestaj();

            reportViewer1.RefreshReport(); 

        }

        private void UcitajIzvjestaj()
        {

            var prisustva = db.PrisustvoIB180079
                .Include(x => x.Student)
                .Include(x => x.Nastava.Predmet)
                .Where(x => x.Nastava.ProstorijaId == odabranaProstorija.Id)
                .ToList();

            var tblPrisustva = new dsDLWMS.dsPrisustvaDataTable();

            for (int i = 0; i < prisustva.Count(); i++)
            {

                var Red = tblPrisustva.NewdsPrisustvaRow();

                Red.Rb = (i + 1).ToString();
                Red.Predmet = prisustva[i]?.Nastava?.Predmet?.Naziv ?? "N/A";
                Red.Vrijeme = prisustva[i]?.Nastava?.Vrijeme ?? "N/A";
                Red.Indeks = prisustva[i]?.Student?.BrojIndeksa ?? "N/A";
                Red.Student = $"{prisustva[i]?.Student?.Ime ?? "N/A"} {prisustva[i]?.Student?.Prezime ?? "N/A"}";

                tblPrisustva.Rows.Add( Red );

            }

            var rds = new ReportDataSource();

            rds.Value = tblPrisustva;
            rds.Name = "dsPrisustvo";

            reportViewer1.LocalReport.DataSources.Add( rds );

            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("prostorija", odabranaProstorija?.Naziv ?? "N/A"));
            rpc.Add(new ReportParameter("broj", prisustva.Count().ToString()  ));

            reportViewer1.LocalReport.SetParameters( rpc );

        }
    }
}
