using DLWMS.Data.IspitIB180079;
using DLWMS.Infrastructure;
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
            // prostorije[0] = AMF1 -> Id = 1 -> Broj 2
            // prostorije[1] = UC7  -> Id = 2 -> Broj 1
            // prostorije[2] = AKS  -> Id = 3 -> Broj 1

            // db.Nastave

            // nastave[0] = Id = 1 , ProstorijaId = 1
            // nastave[1] = Id = 2 , ProstorijaId = 2
            // nastave[2] = Id = 3 , ProstorijaId = 3
            // nastave[3] = Id = 4 , ProstorijaId = 1

            var prostorije = db.ProstorijeIB180079.ToList();

            for (int i = 0; i < prostorije.Count(); i++)
            {
                // pros[0] = AMF 1 Id = 1 == 1

                prostorije[i].Broj = db.NastavaIB180079
                    .Where(x => x.ProstorijaId == prostorije[i].Id)
                    .Count();
            }



            dgvProstorije.DataSource = prostorije;


        }

        private void btnNovaProstorija_Click(object sender, EventArgs e)
        {

            var frmNovaProstorija = new frmNovaProstorijaIB180079();

            if(frmNovaProstorija.ShowDialog() == DialogResult.OK)
            {
                UcitajProstorije();
            }


        }
    }
}
