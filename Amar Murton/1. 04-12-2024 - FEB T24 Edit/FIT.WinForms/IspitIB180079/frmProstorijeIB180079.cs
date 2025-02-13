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
            // prostorije[0] = AMF2
            // prostorije[1] = UC2
            // prostorije[2] = AKS

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

        private void btnNovaProstorija_Click(object sender, EventArgs e)
        {

            var frmNova = new frmNovaProstorijaIB180079();
            if (frmNova.ShowDialog() == DialogResult.OK)
            {
                UcitajProstorije();

                MessageBox.Show("Prostorija je uspješno dodana","Informacija",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }

        }

        private void dgvProstorije_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // prostorije[0] = AMF2
            // prostorije[1] = UC2
            // prostorije[2] = AKS

            var odabranaProstorija = prostorije[e.RowIndex];


            if (e.ColumnIndex < 5)
            {

                var frmEditProstorija = new frmNovaProstorijaIB180079(odabranaProstorija);

                if(frmEditProstorija.ShowDialog() == DialogResult.OK)
                {
                    UcitajProstorije();

                    MessageBox.Show("Prostorija je uspješno editovana", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }

        }
    }
}
