using FIT.Data.IspitIB220152;
using FIT.Infrastructure;
using FIT.WinForms.Izvjestaji;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIT.WinForms.IspitIB220152
{
    public partial class frmProstorijeIB220152 : Form
    {
        DLWMSDbContext db = new DLWMSDbContext();
        List<ProstorijeIB220152> prostorije;
        public frmProstorijeIB220152()
        {
            InitializeComponent();
        }

        private void frmProstorijeIB220152_Load(object sender, EventArgs e)
        {
            dgvPodaci.AutoGenerateColumns = false;
            UcitajPodatke();
        }

        private void UcitajPodatke()
        {
            prostorije = db.ProstorijeIB220152.ToList();

            for (int i = 0; i < prostorije.Count(); i++)
            {
                prostorije[i].Broj = db.NastavaIB220152
                    .Where(x => x.ProstorijeId == prostorije[i].Id)
                    .Count();
            }

            if (prostorije != null)
            {
                dgvPodaci.DataSource = null;
                dgvPodaci.DataSource = prostorije;
            }

        }

        private void btnNovaProstorija_Click(object sender, EventArgs e)
        {
            var novaProstorija = new frmNovaProstorijaIB220152();
            if (novaProstorija.ShowDialog() == DialogResult.OK)
            {
                UcitajPodatke();
                MessageBox.Show("Uspjesno ste dodali novu prostoriju!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvPodaci_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var odabranaProstorija = prostorije[e.RowIndex];

            if (e.ColumnIndex < 5)
            {
                var frmEditProstorije = new frmNovaProstorijaIB220152(odabranaProstorija);
                if (frmEditProstorije.ShowDialog() == DialogResult.OK)
                {
                    UcitajPodatke();
                    MessageBox.Show("Uspjesno ste editovali prostoriju!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvPodaci_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            var odabranaProstorija = prostorije[e.RowIndex];

            if (e.ColumnIndex == 5)
            {
                var novaForma = new frmNastavaIB220152(odabranaProstorija);
                if (novaForma.ShowDialog() == DialogResult.OK)
                {
                    UcitajPodatke();
                }
            }
            else if (e.ColumnIndex == 6)
            {
                var frmPrisustva = new frmPrisustvoIB180079(odabranaProstorija);

                frmPrisustva.ShowDialog();


            }
        }

        private void btnPrintaj_Click(object sender, EventArgs e)
        {
            var odabranaProstorija = dgvPodaci.SelectedRows[0].DataBoundItem as ProstorijeIB220152;


            if(odabranaProstorija != null)
            {
                var frmIzvjestaj = new frmIzvjestaji(odabranaProstorija);

                frmIzvjestaj.ShowDialog();

            }


        }
    }
}
