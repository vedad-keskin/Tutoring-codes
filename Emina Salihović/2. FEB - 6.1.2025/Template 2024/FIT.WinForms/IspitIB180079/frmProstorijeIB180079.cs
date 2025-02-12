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
            // alt + enter
            UcitajProstorije();
        }

        private void UcitajProstorije()
        {

            // prostorije[0] = AMF1 -> Broj -> 2 -> Id
            // prostorije[1] = UC2  -> Broj -> 1 -> Id
            // prostorije[2] = AKS  -> Broj -> 1 -> Id


            prostorije = db.ProstorijeIB180079.ToList();

            for (int i = 0; i < prostorije.Count(); i++)
            {

                prostorije[i].Broj = db.NastavaIB180079
                    .Where(x => x.ProstorijaId == prostorije[i].Id)
                    .Count();

            }

            if (prostorije != null)
            {

                dgvProstorije.DataSource = null;
                dgvProstorije.DataSource = prostorije;

            }



        }

        private void btnNovaProstorija1_Click(object sender, EventArgs e)
        {

            frmNovaProstorijaIB180079 frmNova = new frmNovaProstorijaIB180079();

            if (frmNova.ShowDialog() == DialogResult.OK)
            {
                UcitajProstorije();
            }


        }

        private void dgvProstorije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // prostorije[0] = AMF1 -> Broj -> 2 -> Id
            // prostorije[1] = UC2  -> Broj -> 1 -> Id
            // prostorije[2] = AKS  -> Broj -> 1 -> Id

            var odabranaProstorija = prostorije[e.RowIndex];

            if (e.ColumnIndex < 5)
            {
                var frmEditProstorija = new frmNovaProstorijaIB180079(odabranaProstorija);

                if (frmEditProstorija.ShowDialog() == DialogResult.OK)
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

                var frmNastave = new frmNastavaIB180079(odabranaProstorija);

                if (frmNastave.ShowDialog() == DialogResult.OK)
                {
                    UcitajProstorije();
                }

            }
            if (e.ColumnIndex == 6)
            {

                var frmPrisustvo = new frmPrisustvoIB180079(odabranaProstorija);

                frmPrisustvo.ShowDialog();

            }


        }

        private void btnPrintaj_Click(object sender, EventArgs e)
        {
            var odabranaProstorija = dgvProstorije.SelectedRows[0].DataBoundItem as ProstorijeIB180079;

            var frmIzvjestaj = new frmIzvjestaji(odabranaProstorija);

            frmIzvjestaj.ShowDialog();


        }
    }
}
