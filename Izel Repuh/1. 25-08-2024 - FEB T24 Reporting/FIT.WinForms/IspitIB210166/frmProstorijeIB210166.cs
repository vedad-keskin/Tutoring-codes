using FIT.Data.IspitIB210166;
using FIT.Infrastructure;
using FIT.WinForms.Izvjestaji;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IspitIB210166
{
    public partial class frmProstorijeIB210166 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<ProstorijeIB210166> prostorije;
        public frmProstorijeIB210166()
        {
            InitializeComponent();
        }

        private void UcitajSve()
        {
            prostorije = db.ProstorijeIB210166.ToList();

            // pros[0] = AMF2 --> Broj -> 1 
            // pros[1] = UC1  --> Broj -> 1

            for (int i = 0; i < prostorije.Count(); i++)
            {
                prostorije[i].BrojPredmeta = db.NastavaIB210166
                    .Where(x => x.ProstorijeId == prostorije[i].Id)
                    .Count();
            }


            if (prostorije.Count > 0)
            {
                dgvProstorijeIB210166.DataSource = null;
                dgvProstorijeIB210166.DataSource = prostorije;
            }
        }


        private void frmProstorijeIB210166_Load(object sender, EventArgs e)
        {
            dgvProstorijeIB210166.AutoGenerateColumns = false;
            UcitajSve();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNovaProstorijaIB180079 frmNova = new frmNovaProstorijaIB180079();

            if (frmNova.ShowDialog() == DialogResult.OK)
            {
                UcitajSve();
                MessageBox.Show("Dodala se prostorija", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvProstorijeIB210166_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // pros[0] = AMF2
            // pros[1] = UC1 

            var odabranaProstorija = prostorije[e.RowIndex];


            if (e.ColumnIndex < 5)
            {
                frmNovaProstorijaIB180079 frmModfikacija = new frmNovaProstorijaIB180079(odabranaProstorija);


                if (frmModfikacija.ShowDialog() == DialogResult.OK)
                {
                    UcitajSve();
                    MessageBox.Show("Prostorija se modifikovala", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvProstorijeIB210166_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaProstorija = prostorije[e.RowIndex];


            if (e.ColumnIndex == 5)
            {
                frmNastavaIB180079 frmNastava = new frmNastavaIB180079(odabranaProstorija);
                if (frmNastava.ShowDialog() == DialogResult.OK)
                {
                    UcitajSve();
                }
            }
            else if (e.ColumnIndex == 6)
            {

                frmPrisustvoIB180079 frmPrisustvo = new frmPrisustvoIB180079(odabranaProstorija);

                frmPrisustvo.ShowDialog();

            }




        }

        private void button2_Click(object sender, EventArgs e)
        {

            var odabranaProstorija = dgvProstorijeIB210166.SelectedRows[0].DataBoundItem as ProstorijeIB210166;


            frmIzvjestaji frmIzvjestaj = new frmIzvjestaji(odabranaProstorija);

            frmIzvjestaj.ShowDialog();



        }
    }
}
