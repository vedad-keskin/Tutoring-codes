using DLWMS.Data;
using DLWMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace DLWMS.WinApp.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private Student? odabraniStudent;
        DLWMSContext db = new DLWMSContext();

        //public frmIzvjestaji()
        //{
        //    InitializeComponent();
        //}

        public frmIzvjestaji(Student? odabraniStudent)
        {
            InitializeComponent();            
            this.odabraniStudent = odabraniStudent;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            IsprintajIzvjestaj();

            reportViewer1.RefreshReport(); 
        }

        private void IsprintajIzvjestaj()
        {
            var razmjeneStudenta = db.RazmjeneIB180079
                .Include(x => x.Univerzitet.Drzava)
                .Where(x => x.StudentId == odabraniStudent.Id)
                .ToList();


            var tblRazmjene = new dsDLWMS.dsRazmjeneDataTable();

            for (int i = 0; i < razmjeneStudenta.Count(); i++)
            {

                var Red = tblRazmjene.NewdsRazmjeneRow();

                Red.Rb = (i + 1).ToString();
                Red.Univerzitet = razmjeneStudenta[i]?.Univerzitet?.ToString() ?? "N/A";
                Red.Pocetak = razmjeneStudenta[i].DatumPocetak.ToString("dd.MM.yyyy");
                Red.Kraj = razmjeneStudenta[i].DatumKraj.ToString("dd.MM.yyyy");
                Red.ECTS = razmjeneStudenta[i].ECTS.ToString();
                Red.Okoncano = razmjeneStudenta[i].Okoncana ? "DA" : "NE";

                tblRazmjene.Rows.Add(Red);

            }

            var rds = new ReportDataSource();

            rds.Value = tblRazmjene;
            rds.Name = "dsRazmjene";

            reportViewer1.LocalReport.DataSources.Add(rds);


            var rpc = new ReportParameterCollection();

            var sumaECTS = razmjeneStudenta?.Sum(x => x.ECTS) ?? 0;

            rpc.Add(new ReportParameter("student",odabraniStudent.ToString()));
            rpc.Add(new ReportParameter("ects", sumaECTS.ToString()));

            reportViewer1.LocalReport.SetParameters(rpc);

        }
    }
}
