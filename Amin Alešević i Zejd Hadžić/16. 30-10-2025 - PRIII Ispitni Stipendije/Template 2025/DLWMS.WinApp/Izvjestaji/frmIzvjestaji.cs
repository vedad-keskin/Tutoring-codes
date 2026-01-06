using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;

namespace DLWMS.WinApp.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private StipendijeGodineIB180079? odabranaStipendijaGodina;
        DLWMSContext db = new DLWMSContext();

        //public frmIzvjestaji()
        //{
        //    InitializeComponent();            
        //}

        public frmIzvjestaji(StipendijeGodineIB180079? odabranaStipendijaGodina)
        {
            InitializeComponent();            
            this.odabranaStipendijaGodina = odabranaStipendijaGodina;
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {

            UcitajReport();

            reportViewer1.RefreshReport(); 
        }

        private void UcitajReport()
        {

            var studentiStipendije = db.StudentiStipendijeIB180079
                .Include(x=> x.Student)
                .Include(x=> x.StipendijaGodina.Stipendija)
                .Where(x=> x.StipendijaGodinaId == odabranaStipendijaGodina.Id)
                .ToList();


            var tblStipendije = new dsDLWMS.dsStipendijeDataTable();

            for (int i = 0; i < studentiStipendije.Count(); i++)
            {

                var Red = tblStipendije.NewdsStipendijeRow();

                Red.Rb = (i + 1).ToString();
                Red.Student = studentiStipendije[i].Student.ToString();
                Red.Iznos = studentiStipendije[i].StipendijaGodina.Iznos.ToString();
                Red.Ukupno = studentiStipendije[i].StipendijaGodina.UkupnoInfo.ToString();


                tblStipendije.Rows.Add( Red );

                
            }

            var rds = new ReportDataSource();

            rds.Name = "dsStipendije";
            rds.Value = tblStipendije;

            reportViewer1.LocalReport.DataSources.Add( rds );

            var rpc = new ReportParameterCollection();

            rpc.Add(new ReportParameter("godina", odabranaStipendijaGodina.Godina));
            rpc.Add(new ReportParameter("stipendija", odabranaStipendijaGodina.Stipendija.Naziv));

            var ukupno = studentiStipendije.Sum(x => x.StipendijaGodina.UkupnoInfo);

            rpc.Add(new ReportParameter("ukupno", ukupno.ToString()));


            reportViewer1.LocalReport.SetParameters( rpc ); 





        }
    }
}
