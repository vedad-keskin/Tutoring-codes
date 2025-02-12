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

            // ALT + ENTER
            UcitajProstorije();

        }

        private void UcitajProstorije()
        {
            // prostorije[0] = AMF1  -> Broj
            // prostorije[1] = UC1   -> Broj
            // prostorije[2] = AKS   -> Broj

            // List<Prostorije>

            prostorije = db.ProstorijeIB180079.ToList();

            for (int i = 0; i < prostorije.Count(); i++) // 0 1 2 
            {

                prostorije[i].Broj = db.NastavaIB180079

                    //                       1 == 1
                    .Where(x => x.ProstorijaId == prostorije[i].Id)
                    .Count();

            }


            if (prostorije != null)
            {

                dgvProstorije.DataSource = null;
                dgvProstorije.DataSource = prostorije;

            }



        }

        private void btnNovaProstorija_Click(object sender, EventArgs e)
        {

            var frmNovaProstorija = new frmNovaProstorijaIB180079();

            if (frmNovaProstorija.ShowDialog() == DialogResult.OK)
            {
                UcitajProstorije();
            }

        }

        private void dgvProstorije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // e --> RED 1 - KOLONI 3

            // prostorije[0] = AMF1  -> Broj
            // prostorije[1] = UC1   -> Broj
            // prostorije[2] = AKS   -> Broj

            // List<Prostorije>

            var odabranaProstorija = prostorije[e.RowIndex];


            if (e.ColumnIndex < 5)
            {


                var frmEditProstorije = new frmNovaProstorijaIB180079(odabranaProstorija);

                if (frmEditProstorije.ShowDialog() == DialogResult.OK)
                {
                    UcitajProstorije();
                }


            }



        }

        private void dgvProstorije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //var odabranaProstorija = prostorije[e.RowIndex];
            var odabranaProstorija = dgvProstorije.SelectedRows[0].DataBoundItem as ProstorijeIB180079;

            if (e.ColumnIndex == 5)
            {

                var frmNastava = new frmNastavaIB180079(odabranaProstorija);

                if (frmNastava.ShowDialog() == DialogResult.OK)
                {
                    UcitajProstorije();
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
            var odabranaProstorija = dgvProstorije.SelectedRows[0].DataBoundItem as ProstorijeIB180079;


            var frmIzvjestaj = new frmIzvjestaji(odabranaProstorija);

            frmIzvjestaj.ShowDialog();


        }
    }
}
