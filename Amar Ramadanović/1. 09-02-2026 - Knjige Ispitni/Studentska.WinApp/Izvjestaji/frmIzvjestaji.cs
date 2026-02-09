using Microsoft.Reporting.WinForms;

namespace Studentska.WinApp.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {

        public frmIzvjestaji()
        {
            InitializeComponent();
            reportViewer1.LocalReport.ReportEmbeddedResource =
                "Studentska.WinApp.Izvjestaji.rptStudentiUplate.rdlc";
        }

        private void frmIzvjestaji_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }
    }
}
