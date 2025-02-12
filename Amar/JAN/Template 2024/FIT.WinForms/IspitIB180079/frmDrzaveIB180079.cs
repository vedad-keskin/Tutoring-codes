using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Izvjestaji;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IspitIB180079
{
    public partial class frmDrzaveIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<DrzaveIB180079> drzave;
        public frmDrzaveIB180079()
        {
            InitializeComponent();
        }

        private void frmDrzaveIB180079_Load(object sender, EventArgs e)
        {
            dgvDrzave.AutoGenerateColumns = false;
            UcitajVrijeme();
            UcitajDrzave();

        }

        private void UcitajDrzave()
        {
            // drzave[0] = BIH -> Id = 1 -> true  -> Slika -> Broj 2
            // drzave[1] = NOV -> Id = 2 -> true  -> Slika -> Broj 1
            // drzave[2] = SVE -> Id = 3 -> false -> Slika -> Broj 1

            drzave = db.DrzaveIB180079.ToList();

            for (int i = 0; i < drzave.Count(); i++)
            {
                drzave[i].Broj = db.GradoviIB180079
                    .Where(x => x.DrzavaId == drzave[i].Id)
                    .Count();
            }


            if (drzave != null)
            {

                dgvDrzave.DataSource = null;
                dgvDrzave.DataSource = drzave;

            }


        }

        private void timer_Tick(object sender, EventArgs e)
        {

            UcitajVrijeme();

        }

        private void UcitajVrijeme()
        {
            tsslVrijeme.Text = $"Trenutno vrijeme: {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var frmNovaDrzava = new frmNovaDrzavaIB180079();

            if (frmNovaDrzava.ShowDialog() == DialogResult.OK)
            {
                UcitajDrzave();
            }
        }

        private void dgvDrzave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranaDrzava = drzave[e.RowIndex];

            if (e.ColumnIndex < 4)
            {
                var frmEditDrzave = new frmNovaDrzavaIB180079(odabranaDrzava);

                if (frmEditDrzave.ShowDialog() == DialogResult.OK)
                {
                    UcitajDrzave();
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
                    UcitajDrzave();
                }


            }



        }

        private void button2_Click(object sender, EventArgs e)
        {

            var odabranaDrzava = dgvDrzave.SelectedRows[0].DataBoundItem as DrzaveIB180079;

            if(odabranaDrzava != null )
            {
                var frmIzvjestaj = new frmIzvjestaji(odabranaDrzava);

                frmIzvjestaj.ShowDialog();
            }


        }
    }
}
