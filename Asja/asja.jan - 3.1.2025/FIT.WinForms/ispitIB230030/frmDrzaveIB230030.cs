using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FIT.Data.IspitIB230030;
using FIT.Infrastructure;

namespace FIT.WinForms.ispitIB230030
{
    public partial class frmDrzaveIB230030 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<DrzaveIB230030> drzave;
        public frmDrzaveIB230030()
        {
            InitializeComponent();
        }

        private void frmDrzaveIB230030_Load(object sender, EventArgs e)
        {
            dgvDrzave.AutoGenerateColumns = false;
            ucitajVrijeme();
            ucitajDrzave();
        }

        private void ucitajDrzave()
        {
            drzave = db.DrzaveIB230030.ToList();

            for (int i = 0; i < drzave.Count(); i++)
            {
                drzave[i].Broj = db.GradoviIB230030.
                    Where(x => x.DrzavaID == drzave[i].Id).Count();
            }

            if (drzave != null)
            {
                dgvDrzave.DataSource = null;
                dgvDrzave.DataSource = drzave;
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ucitajVrijeme();
        }

        private void ucitajVrijeme()
        {
            tsslVrijeme.Text = $"Trenutno vrijeme: " +
                $"{DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void btnNovaDrzava_Click(object sender, EventArgs e)
        {
            var frmNovaDrzava = new frmNovaDrzavaIB230030();
            if (frmNovaDrzava.ShowDialog() == DialogResult.OK)
            {
                ucitajDrzave();
                MessageBox.Show("dodali ste novu drzavu", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvDrzave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranaDrzava = drzave[e.RowIndex];
            if (e.ColumnIndex < 4)
            {
                var frmEditDrzave = new frmNovaDrzavaIB230030(odabranaDrzava);
                if (frmEditDrzave.ShowDialog() == DialogResult.OK)
                {
                    ucitajDrzave();
                    MessageBox.Show("drzava je uredjena", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvDrzave_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaDrzava = drzave[e.RowIndex];


            if (e.ColumnIndex == 4)
            {

                var frmGradovi = new frmGradoviIB180079(odabranaDrzava);

                if (frmGradovi.ShowDialog() == DialogResult.OK)
                {
                    ucitajDrzave();
                }
            }
        }
    }
}