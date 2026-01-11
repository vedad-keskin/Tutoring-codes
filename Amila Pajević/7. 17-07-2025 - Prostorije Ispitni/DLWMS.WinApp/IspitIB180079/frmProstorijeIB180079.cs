using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
using DLWMS.WinApp.Izvjestaji;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLWMS.WinApp.IspitIB180079
{
    public partial class frmProstorijeIB180079 : Form
    {
        DLWMSContext db = new DLWMSContext();
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
            // prostorije[0] = AMF1 --> Broj = 0 --> 2
            // prostorije[1] = AMF3 --> Broj = 0 --> 1
            // prostorije[2] = UC1  --> Broj = 0 --> 0

            prostorije = db.ProstorijeIB180079.ToList();

            for (int i = 0; i < prostorije.Count(); i++) // 0 1 2 
            {

                // prostorije[0] - AMF1 = Id = 1 ---> Broj = 2
                // prostorije[1] - AMF3 = Id = 2 ---> Broj = 1
                // prostorije[2] - UC1 = Id = 3 ---> Broj = 0

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

            if (e.ColumnIndex < 5)
            {

                var odabranaProstorija = prostorije[e.RowIndex];
                //var odabranaProstorija2 = dgvProstorije.SelectedRows[0].DataBoundItem as ProstorijeIB180079;


                var frmEditProstorija = new frmNovaProstorijaIB180079(odabranaProstorija);

                if (frmEditProstorija.ShowDialog() == DialogResult.OK)
                {
                    UcitajProstorije();
                }

            }


        }

        private void dgvProstorije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 5)
            {

                var odabranaProstorija = prostorije[e.RowIndex];
                //var odabranaProstorija2 = dgvProstorije.SelectedRows[0].DataBoundItem as ProstorijeIB180079;


                var frmNastave = new frmNastavaIB180079(odabranaProstorija);

                if (frmNastave.ShowDialog() == DialogResult.OK)
                {
                    UcitajProstorije();
                }


            }
            else if (e.ColumnIndex == 6)
            {

                var odabranaProstorija = dgvProstorije.SelectedRows[0].DataBoundItem as ProstorijeIB180079;

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
