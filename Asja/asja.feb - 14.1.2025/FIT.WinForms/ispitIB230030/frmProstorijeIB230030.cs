using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIT.Data.ispitIB230030;
using FIT.Infrastructure;
using FIT.WinForms.Izvjestaji;

namespace FIT.WinForms.ispitIB230030
{
    public partial class frmProstorijeIB230030 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<ProstorijeIB230030> prostorije;
        public frmProstorijeIB230030()
        {
            InitializeComponent();
        }
        private void frmProstorijeIB230030_Load(object sender, EventArgs e)
        {
            dgvProstorije.AutoGenerateColumns = false;
            UcitajProstorije();
        }

        private void UcitajProstorije()
        {
            prostorije = db.ProstorijeIB230030.ToList();

            for (int i = 0; i < prostorije.Count(); ++i)
            {
                prostorije[i].Broj = db.NastavaIB230030.
                    Where(x => x.ProstorijaID == prostorije[i].Id).Count();
            }
            if (prostorije != null)
            {
                dgvProstorije.DataSource = null;
                dgvProstorije.DataSource = prostorije;
            }

        }

        private void btnnovaprostorija_Click(object sender, EventArgs e)
        {
            var frmNovaProstorija = new frmNovaProstorijaIB230030();
            if (frmNovaProstorija.ShowDialog() == DialogResult.OK)
            {
                UcitajProstorije();
                MessageBox.Show("prostorija uspjesno dodana", "informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProstorije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranaProstorija = prostorije[e.RowIndex];
            if (e.ColumnIndex < 5)
            {

                var frmEditProstorije = new frmNovaProstorijaIB230030(odabranaProstorija);

                if (frmEditProstorije.ShowDialog() == DialogResult.OK)
                {
                    UcitajProstorije();
                    MessageBox.Show("prostorija uspjesno uredjena", "informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvProstorije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranaProstorija = prostorije[e.RowIndex];

            if (e.ColumnIndex == 5)
            {
                var frmNastava = new frmNastavaIB230030(odabranaProstorija);
                if (frmNastava.ShowDialog() == DialogResult.OK)
                    UcitajProstorije();
            }
            else if (e.ColumnIndex == 6)
            {

                var frmPrisutvo = new frmPrisustvoIB180079(odabranaProstorija);

                frmPrisutvo.ShowDialog();

            }
        }

        private void btnPrintaj_Click(object sender, EventArgs e)
        {

            var odabranaProstorija = dgvProstorije.SelectedRows[0].DataBoundItem as ProstorijeIB230030;

            var frmIzvjestaj = new frmIzvjestaji(odabranaProstorija);

            frmIzvjestaj.ShowDialog();

        }
    }
}
