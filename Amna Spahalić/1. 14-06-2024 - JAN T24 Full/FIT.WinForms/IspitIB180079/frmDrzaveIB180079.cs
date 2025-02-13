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
        DrzaveIB180079 odabranaDrzava;
        public frmDrzaveIB180079()
        {
            InitializeComponent();
        }

        private void frmDrzaveIB180079_Load(object sender, EventArgs e)
        {
            dgvDrzave.AutoGenerateColumns = false;
            UcitajDrzave();
            UcitajVrijeme();



        }


        private void UcitajDrzave()
        {

            drzave = db.DrzaveIB180079.ToList();


            for (int i = 0; i < drzave.Count(); i++)
            {
                drzave[i].Broj = db.GradoviIB180079.Where(x => x.DrzavaId == drzave[i].Id).Count();
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
            tsslSat.Text = $"Trenutno vrijeme: {DateTime.Now.ToString("HH:mm:ss")}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNovaDrzavaIB180079 frmNova = new frmNovaDrzavaIB180079();
            if (frmNova.ShowDialog() == DialogResult.OK)
            {
                UcitajDrzave();
                MessageBox.Show("Drzava je dodana");

            }
        }

        private void dgvDrzave_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaDrzava = drzave[e.RowIndex];

            if (e.ColumnIndex != 4)
            {
                frmNovaDrzavaIB180079 frmModifikacija = new frmNovaDrzavaIB180079(odabranaDrzava);
                if (frmModifikacija.ShowDialog() == DialogResult.OK)
                {
                    UcitajDrzave();
                    MessageBox.Show("Drzava je modifikovana");
                }
            }


        }

        private void dgvDrzave_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranaDrzava = drzave[e.RowIndex];

            if (e.ColumnIndex == 4)
            {
                frmGradoviIB180079 frmGradovi = new frmGradoviIB180079(odabranaDrzava);
                if (frmGradovi.ShowDialog() == DialogResult.OK)
                {
                    UcitajDrzave();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            odabranaDrzava = dgvDrzave.SelectedRows[0].DataBoundItem as DrzaveIB180079;

            if(db.GradoviIB180079.Where(x=> x.DrzavaId == odabranaDrzava.Id).Count() != 0)
            {
                frmIzvjestaji frmIzvjestaj = new frmIzvjestaji(odabranaDrzava);
                frmIzvjestaj.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ova država nema gradova","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }


        }
    }
}
