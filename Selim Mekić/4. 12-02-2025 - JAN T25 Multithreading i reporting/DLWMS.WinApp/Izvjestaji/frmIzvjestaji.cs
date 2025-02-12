using DLWMS.Data;
using DLWMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;

namespace DLWMS.WinApp.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private Student odabraniStudent;
        DLWMSContext db = new DLWMSContext();

        public frmIzvjestaji(Student odabraniStudent)
        {
            InitializeComponent();            
            this.odabraniStudent = odabraniStudent;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            UcitajReport();

            reportViewer1.RefreshReport(); 
        }

        private void UcitajReport()
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
                Red.Univerzitet = razmjeneStudenta[i].Univerzitet.ToString();
                Red.Pocetak = razmjeneStudenta[i].DatumPocetak.ToString();
                Red.Kraj = razmjeneStudenta[i].DatumKraj.ToString();
                Red.ECTS = razmjeneStudenta[i].ECTS.ToString();
                Red.Okoncano = razmjeneStudenta[i].Okoncana ? "DA" : "NE";

                tblRazmjene.Rows.Add(Red);

            }

            var rds = new ReportDataSource();
            rds.Name = "dsRazmjene";
            rds.Value = tblRazmjene;


            reportViewer1.LocalReport.DataSources.Add(rds);

            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("studentInfo", odabraniStudent.StudentInfo));

            var sumaECTS = razmjeneStudenta.Sum(x => x.ECTS);

            rpc.Add(new ReportParameter("sumaECTS", sumaECTS.ToString()));

            reportViewer1.LocalReport.SetParameters(rpc);

        }
    }
}
