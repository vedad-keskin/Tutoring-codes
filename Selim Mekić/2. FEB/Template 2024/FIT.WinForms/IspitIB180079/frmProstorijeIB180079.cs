using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
using FIT.WinForms.Izvjestaji;
using Microsoft.EntityFrameworkCore;
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
    public partial class frmProstorijeIB180079 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<ProstorijeIB180079> prostorije;
        public frmProstorijeIB180079()
        {
            InitializeComponent();
        }

        private void frmProstorijeIB180079_Load(object sender, EventArgs e)
        {
            dgvProstorije.AutoGenerateColumns = false;

            UcitajProstorije();
        }

        private void UcitajProstorije()
        {

            prostorije = db.ProstorijeIB180079.ToList();


            for (int i = 0; i < prostorije.Count(); i++)
            {

                prostorije[i].Broj = db.NastavaIB180079.Where(x => x.ProstorijaId == prostorije[i].Id).Count();
            }



            if (prostorije != null)
            {


                dgvProstorije.DataSource = null;
                dgvProstorije.DataSource = prostorije;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmNovaProstorijaIB180079 frmNova = new frmNovaProstorijaIB180079();
            if (frmNova.ShowDialog() == DialogResult.OK)
            {
                UcitajProstorije();
            }
        }

        private void dgvProstorije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranaProstorija = prostorije[e.RowIndex];

            if (e.ColumnIndex < 5)
            {
                frmNovaProstorijaIB180079 frmModifikacija = new frmNovaProstorijaIB180079(odabranaProstorija);
                if (frmModifikacija.ShowDialog() == DialogResult.OK)
                {
                    UcitajProstorije();
                }

            }


        }

        private void dgvProstorije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaProstorija = prostorije[e.RowIndex];

            if (e.ColumnIndex == 5)
            {
                frmNastavaIB180079 frmNastava = new frmNastavaIB180079(odabranaProstorija);
                frmNastava.ShowDialog();

            }
            else if (e.ColumnIndex == 6)
            {
                frmPrisustvoIB180079 frmPrisustva = new frmPrisustvoIB180079(odabranaProstorija);
                frmPrisustva.ShowDialog();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var odabranaProstorija = dgvProstorije.SelectedRows[0].DataBoundItem as ProstorijeIB180079;


            frmIzvjestaji frmIzvjestaj = new frmIzvjestaji(odabranaProstorija);

            if(db.PrisustvoIB180079.Include(x=> x.Nastava)
                .Where(x=> x.Nastava.ProstorijaId == odabranaProstorija.Id)
                .Count() > 0)
            {
                frmIzvjestaj.ShowDialog();
            }
            else
            {
                MessageBox.Show("Prostorija nema prisustava","Upozorenje",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }
    }
}
