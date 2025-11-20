using DLWMS.Infrastructure;
using DLWMS.WinApp.Izvjestaji;

namespace DLWMS.WinApp
{
    public partial class frmPocetna : Form
    {
        DLWMSContext db = new DLWMSContext();

        // dft constr.
        public frmPocetna()
        {
            InitializeComponent();
        }

        private void frmPocetna_Load(object sender, EventArgs e)
        {
            lblKonekcijaInfo.Text = $"Broj studenata u bazi -> {db.Studenti.Count()}";
        }

        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            new frmIzvjestaji().Show();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            lblNaziv.Text = $"Broj stipendija u bazi je {db.StipendijeIB180079.Count()}";
            btnIzvjestaj.Text = "Denis Music";
            btnAction.Text = "PR3";
        }
    }
}
