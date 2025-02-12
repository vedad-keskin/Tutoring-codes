using FIT.Data.IspitIB180079;
using FIT.Infrastructure;
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
                // AMF2.Broj , UC1.Broj , AKS.Broj
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
            frmNovaProstorijaIB180079 frmNova = new frmNovaProstorijaIB180079();
            if (frmNova.ShowDialog() == DialogResult.OK)
            {
                UcitajProstorije();
            }
        }

        private void dgvProstorije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // prostorije[0] = AMF1
            // prostorije[1] = UC1
            // prostorije[2] = AKS


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

            if(e.ColumnIndex == 5)
            {
                frmNastavaIB180079 frmNastava = new frmNastavaIB180079(odabranaProstorija);

                if (frmNastava.ShowDialog() == DialogResult.OK)
                {
                    UcitajProstorije();
                }
            }

            if(e.ColumnIndex == 6)
            {
                frmPrisustvoIB180079 frmPrisustva = new frmPrisustvoIB180079(odabranaProstorija);

                frmPrisustva.ShowDialog();

            }


        }
    }
}
