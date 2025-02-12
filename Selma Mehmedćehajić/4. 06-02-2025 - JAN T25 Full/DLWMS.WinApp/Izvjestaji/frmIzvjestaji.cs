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

            IsprintajReport();

            reportViewer1.RefreshReport(); 
        }

        private void IsprintajReport()
        {

            var razmjene = db.RazmjeneIB180079
                .Include(x => x.Univerzitet.Drzava)
                .Where(x=> x.StudentId == odabraniStudent.Id)
                .ToList();

            var tblRazmjene = new dsDLWMS.dsRazmjenaDataTable();

            for (int i = 0; i < razmjene.Count(); i++)
            {

                var Red = tblRazmjene.NewdsRazmjenaRow();

                Red.Rb = (i + 1).ToString();
                Red.Univerzitet = razmjene[i].Univerzitet.ToString();
                Red.Pocetak = razmjene[i].DatumPocetak.ToString();
                Red.Kraj = razmjene[i].DatumKraj.ToString();
                Red.ECTS = razmjene[i].ECTS.ToString();
                Red.Okoncano = razmjene[i].Okoncana ? "DA" : "NE";

                tblRazmjene.Rows.Add(Red);

            }

            var rds = new ReportDataSource();

            rds.Value = tblRazmjene;
            rds.Name = "dsRazmjene";

            reportViewer1.LocalReport.DataSources.Add(rds);

            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("studentInfo", odabraniStudent.StudentInfo));

            var sumaECTS = razmjene.Sum(x => x.ECTS);

            rpc.Add(new ReportParameter("sumaECTS", sumaECTS.ToString()));

            reportViewer1.LocalReport.SetParameters(rpc);


        }
    }
}
