using DLWMS.Data;
using DLWMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using System.Data;
using System.Security.AccessControl;

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

            var razmjene = db.RazmjeneIB180079
                .Include(x=> x.Univerzitet.Drzava)
                .Include(x=> x.Student)
                .Where(x=> x.StudentId == odabraniStudent.Id)
                .ToList();

            var tblRazmjene = new dsDLWMS.dsRazmjeneDataTable();

            for (int i = 0; i < razmjene.Count(); i++)
            {

                var Red = tblRazmjene.NewdsRazmjeneRow();

                Red.Rb = (i + 1).ToString();

                Red.Univerzitet = razmjene[i].Univerzitet.ToString();

                Red.Pocetak = razmjene[i].DatumPocetak.ToString();
                Red.Kraj = razmjene[i].DatumKraj.ToString();
                Red.ECTS = razmjene[i].ECTS.ToString();
                Red.Okocano = razmjene[i].Okoncana ? "DA" : "NE";

                tblRazmjene.Rows.Add(Red);


            }

            var rds = new ReportDataSource();

            rds.Value = tblRazmjene;
            rds.Name = "dsRazmjene";

            reportViewer1.LocalReport.DataSources.Add(rds);


            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("studentInfo",odabraniStudent.StudentInfo));

            //int suma = 0;

            //for (int i = 0; i < razmjene.Count(); i++)
            //{
            //    suma += razmjene[i].ECTS;
            //}

            int suma = razmjene.Sum(x => x.ECTS);

            rpc.Add(new ReportParameter("sumaECTS", suma.ToString()));


            reportViewer1.LocalReport.SetParameters(rpc);


        }
    }
}
