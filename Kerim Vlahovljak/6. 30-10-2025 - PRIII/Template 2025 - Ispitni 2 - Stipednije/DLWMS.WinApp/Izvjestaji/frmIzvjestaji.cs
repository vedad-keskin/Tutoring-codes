using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace DLWMS.WinApp.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private StipendijeGodineIB180079? odabranaStipendijaGodina;
        DLWMSContext db = new DLWMSContext();

        public frmIzvjestaji()
        {
            InitializeComponent();            
        }

        public frmIzvjestaji(StipendijeGodineIB180079? odabranaStipendijaGodina)
        {
            InitializeComponent();            
            this.odabranaStipendijaGodina = odabranaStipendijaGodina;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            IsprintajIzvjestaj();

            reportViewer1.RefreshReport(); 
        }

        private void IsprintajIzvjestaj()
        {


            // SREDITI TABELU

            var studentStipendije = db.StudentiStipendijeIB180079
                .Include(x => x.Student)
                .Include(x => x.StipendijaGodina)
                .Where(x => x.StipendijaGodinaId == odabranaStipendijaGodina.Id)
                .ToList();


            var tblStudentStipendije = new dsDLWMS.dsStipendijeDataTable();

            for (int i = 0; i < studentStipendije.Count(); i++)
            {

                var Red = tblStudentStipendije.NewdsStipendijeRow();

                Red.Rb = (i + 1).ToString();
                Red.Student = studentStipendije[i]?.Student?.ToString() ?? "N/A";
                Red.Iznos = studentStipendije[i]?.StipendijaGodina?.Iznos.ToString() ?? "0";
                Red.Ukupno = studentStipendije[i]?.StipendijaGodina?.UkupnoInfo.ToString() ?? "0";


                tblStudentStipendije.Rows.Add( Red );

            }


            var rds = new ReportDataSource();

            rds.Value = tblStudentStipendije;
            rds.Name = "dsStipendije";

            reportViewer1.LocalReport.DataSources.Add( rds );



            // SREDITI PARAMETRE


            var rpc = new ReportParameterCollection();

            var sumaUkupno = studentStipendije.Sum( x => x.Ukupno );

            rpc.Add(new ReportParameter("godina",odabranaStipendijaGodina.Godina));
            rpc.Add(new ReportParameter("stipendija",odabranaStipendijaGodina.Stipendija.ToString()));
            rpc.Add(new ReportParameter("ukupno", sumaUkupno.ToString()));


            reportViewer1.LocalReport.SetParameters( rpc );


        }
    }
}
